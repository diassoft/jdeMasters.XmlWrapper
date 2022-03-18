using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using jdeMasters.Components.XmlWrapper.XmlRequest;
using jdeMasters.Components.XmlWrapper.XmlResponse;
using jdeMasters.Components.XmlWrapper.Utils;
using jdeMasters.Components.XmlWrapper.Exceptions;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Data;
using static System.Net.WebRequestMethods;

namespace jdeMasters.Components.XmlWrapper
{
    /// <summary>
    /// Helper class to interact with the Xml Wrapper
    /// </summary>
    public static class JDEXmlInteropManager
    {

        /// <summary>
        /// Gets the propert JDEXmlRequest object based on the jdeRequest type attribute
        /// </summary>
        /// <param name="jdeOperationString">An string containing the entire jdeRequest or jdeResponse</param>
        /// <returns>The <see cref="JDEXmlOperation">JDEXmlOperation</see> containing the object based on the input string.</returns>
        public static JDEXmlOperation GetOperationFromString(string jdeOperationString)
        {
            try
            {
                // The Return Operation
                JDEXmlOperation jdeOperation = null;

                // Loads the Xml Doc
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(jdeOperationString);

                // Verify if the type is a jdeRequest
                XmlNodeList root = xmlDoc.GetElementsByTagName("jdeRequest");

                if (root.Count > 0)
                {
                    // This is a jdeRequest
                    XmlNode jdeRequestNode = root[0];

                    // Look for Type Attribute
                    XmlAttribute jdeRequestTypeAttribute = jdeRequestNode.Attributes["type"];

                    if (jdeRequestTypeAttribute != null)
                    {
                        // Check the value now
                        if (jdeRequestTypeAttribute.Value.ToUpper() == "CALLMETHOD")
                        {
                            // Call Method Request - Used to call business functions or retrieve a business function template

                            // Check whether it's a call method or call method template
                            if (xmlDoc.GetElementsByTagName("callMethodTemplate").Count > 0)
                                jdeOperation = JDEXmlRequestCallMethodTemplate.DeserializeFromText<JDEXmlRequestCallMethodTemplate>(jdeOperationString);
                            else
                                jdeOperation = JDEXmlRequestCallMethod.DeserializeFromText<JDEXmlRequestCallMethod>(jdeOperationString);
                        }
                        else if (jdeRequestTypeAttribute.Value.ToUpper() == "LIST")
                        {
                            // List Request - Used to create / read or delete a list on the Server

                            // Check the action type
                            XmlNodeList jdeRequestListActionNodes;
                            
                            // Get Element, try lower and, if not found, upper case
                            jdeRequestListActionNodes = xmlDoc.GetElementsByTagName("action");
                            if (jdeRequestListActionNodes.Count == 0) jdeRequestListActionNodes = xmlDoc.GetElementsByTagName("ACTION");

                            if (jdeRequestListActionNodes.Count > 0)
                            {
                                // There is an action, check type then
                                XmlNode jdeRequestListAction = jdeRequestListActionNodes[0];

                                // Try type lower or upper case
                                XmlAttribute listType;
                                
                                listType = jdeRequestListAction.Attributes["type"];
                                if (listType == null) listType = jdeRequestListAction.Attributes["TYPE"];

                                // Check if List Type was found
                                if (listType != null)
                                {
                                    string listTypeString = listType.Value.Trim().ToUpper();

                                    if (listTypeString == "CREATELIST")
                                        jdeOperation = JDEXmlRequestListCreate.DeserializeFromText<JDEXmlRequestListCreate>(jdeOperationString);
                                    else if (listTypeString == "GETGROUP")
                                        jdeOperation = JDEXmlRequestListGetGroup.DeserializeFromText<JDEXmlRequestListGetGroup>(jdeOperationString);
                                    else if (listTypeString == "DELETELIST")
                                        jdeOperation = JDEXmlRequestListDelete.DeserializeFromText<JDEXmlRequestListDelete>(jdeOperationString);
                                    else
                                        jdeOperation = null;
                                }
                                else
                                {
                                    // There is no Action Type on the Response. Return null.
                                    jdeOperation = null;
                                }
                            }
                        }
                        else if (jdeRequestTypeAttribute.Value.ToUpper() == "CUSTOMQUERY")
                        {
                            // Custom Query Request - Custom type that allows to performe a free form sql statement
                            // Table names must be inside []s, if you want them to use the OCM Mapping Rules
                            jdeOperation = JDEXmlRequestCustomQuery.DeserializeFromText<JDEXmlRequestCustomQuery>(jdeOperationString);
                        }
                        else
                        {
                            // The Request type isn't valid. It should be either callMethod or list
                            jdeOperation = null;
                        }
                    }
                    else
                    {
                        // There is no Type attribute , then return null
                        jdeOperation = null;
                    }
                }
                else
                {
                    // Check for a jdeResponse
                    root = xmlDoc.GetElementsByTagName("jdeResponse");

                    if (root.Count > 0)
                    {
                        // This is a jdeResponse
                        XmlNode jdeResponseNode = root[0];

                        // Look for Type Attribute
                        XmlAttribute jdeResponseTypeAttribute = jdeResponseNode.Attributes["type"];

                        if (jdeResponseTypeAttribute != null)
                        {
                            // Check the value now
                            if (jdeResponseTypeAttribute.Value.ToUpper() == "CALLMETHOD")
                            {
                                // Check whether it's a call method or call method template
                                if (xmlDoc.GetElementsByTagName("callMethodTemplate").Count > 0)
                                    jdeOperation = JDEXmlResponseCallMethod.DeserializeFromText<JDEXmlResponseCallMethod>(jdeOperationString);
                                else
                                {
                                    // Look for Error Reports
                                    if (xmlDoc.GetElementsByTagName("errorReport").Count > 0)
                                        jdeOperation = JDEXmlResponseErrorReport.DeserializeFromText<JDEXmlResponseErrorReport>(jdeOperationString);
                                    else
                                        jdeOperation = JDEXmlResponseCallMethod.DeserializeFromText<JDEXmlResponseCallMethod>(jdeOperationString);
                                }

                            }
                            else if (jdeResponseTypeAttribute.Value.ToUpper() == "LIST")
                            {
                                // Check the action type
                                XmlNodeList jdeResponseListActionNodes = xmlDoc.GetElementsByTagName("action");

                                if (jdeResponseListActionNodes.Count > 0)
                                {
                                    // There is an action, check type then
                                    XmlNode jdeResponseListAction = jdeResponseListActionNodes[0];
                                    XmlAttribute listType = jdeResponseListAction.Attributes["type"];

                                    if (listType != null)
                                    {
                                        string listTypeString = listType.Value.Trim().ToUpper();

                                        if (listTypeString == "CREATELIST")
                                            jdeOperation = JDEXmlRequestListCreate.DeserializeFromText<JDEXmlRequestListCreate>(jdeOperationString);
                                        else if (listTypeString == "GETGROUP")
                                            jdeOperation = JDEXmlRequestListGetGroup.DeserializeFromText<JDEXmlRequestListGetGroup>(jdeOperationString);
                                        else if (listTypeString == "DELETELIST")
                                            jdeOperation = JDEXmlRequestListDelete.DeserializeFromText<JDEXmlRequestListDelete>(jdeOperationString);
                                        else
                                            jdeOperation = null;
                                    }
                                    else
                                    {
                                        // There is no Action Type on the Response. Return null.
                                        jdeOperation = null;
                                    }
                                }
                            }
                            else if (jdeResponseTypeAttribute.Value.ToUpper() == "CUSTOMQUERY")
                            {
                                // It's the response of a custom query
                                jdeOperation = JDEXmlResponseCustomQuery.DeserializeFromText<JDEXmlResponseCustomQuery>(jdeOperationString);
                            }
                            else
                            {
                                // The Request type isn't valid. It should be either callMethod or list
                                jdeOperation = null;
                            }
                        }
                    }
                    else
                    {
                        // This is neither a jdeRequest nor a jdeResponse. It ain't a valid object then, so return null.
                        jdeOperation = null;
                    }
                }

                // Retuns the jdeOperation
                return jdeOperation;
            }
            catch 
            {
                return null;
            }
        }

        /// <summary>
        /// Converts the results of a <see cref="JDEXmlTableData"/> into a datatable
        /// </summary>
        /// <param name="tableData">The <see cref="JDEXmlTableData"/></param>
        /// <returns>A <see cref="DataTable"/> containing the results</returns>
        public static DataTable ConvertJDEXmlTableToDataTable(List<JDEXmlTableData> tableData)
        {
            try
            {
                DataTable dt = new DataTable();

                if (tableData.Count > 0)
                {
                    JDEXmlTableData tmpData = tableData[0];

                    foreach (var c in tmpData.Columns)
                    {
                        dt.Columns.Add(c.Alias);
                    }
                }

                // Loop thru each row of the TableData
                foreach (JDEXmlTableData data in tableData)
                {
                    // List of Data to be transformed in an array later
                    List<object> listOfData = new List<object>();
                    
                    // Add contents to a list
                    foreach (JDEXmlTableDataColumn column in data.Columns)
                    {
                        listOfData.Add(column.Value);
                    }

                    // Add to the data table
                    dt.Rows.Add(listOfData.ToArray<object>());
                }

                return dt;
            }
            catch
            {
                return null;
            }


        }
    }

    /// <summary>
    /// Process Valid Exit Codes.
    /// These are Windows defined codes, and they are available on Winerror.h file.
    /// A full list of error messages is also available at http://www.carrona.org/winerror.html
    /// </summary>
    public enum JDEXmlInteropProcessExitCodes : int
    {
        /// <summary>
        /// The operation completed successfully.
        /// </summary>
        ERROR_SUCCESS = 0,
        /// <summary>
        /// Incorrect function.
        /// </summary>
        ERROR_INVALID_FUNCTION = 1,
        /// <summary>
        /// The system cannot find the file specified.
        /// </summary>
        ERROR_FILE_NOT_FOUND = 2,
        /// <summary>
        /// The system cannot find the path specified.
        /// </summary>
        ERROR_PATH_NOT_FOUND = 3,
        /// <summary>
        /// The process terminated unexpectedly. The system has been shut down.
        /// </summary>
        ERROR_SYSTEM_PROCESS_TERMINATED = 591,
        /// <summary>
        /// The service did not respond to the start or control request in a timely fashion.
        /// </summary>
        ERROR_SERVICE_REQUEST_TIMEOUT = 1053,
        /// <summary>
        /// The process terminated unexpectedly.
        /// </summary>
        ERROR_PROCESS_ABORTED = 1067
    }
}
