using jdeMasters.Components.XmlWrapper.XmlRequest;
using jdeMasters.Components.XmlWrapper.XmlResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdeMasters.Components.XmlWrapper.Exceptions
{

    /// <summary>
    /// Represents an error that occurs when the JDE Xml Interop Process execution failed 
    /// </summary>
    public class JDEProcessFailedException: Exception
    {
        /// <summary>
        /// The Process Exit Code
        /// </summary>
        public JDEXmlInteropProcessExitCodes ExitCode { get; }

        /// <summary>
        /// The request that was made
        /// </summary>
        public JDEXmlOperation JDEXmlRequest { get; }

        /// <summary>
        /// The path of the request file
        /// </summary>
        public string JDEXmlRequestFilename { get; }

        /// <summary>
        /// The response that was received
        /// </summary>
        public JDEXmlOperation JDEXmlResponse { get; }

        /// <summary>
        /// The path of the response file
        /// </summary>
        public string JDEXmlResponseFilename { get; }

        /// <summary>
        /// Initializes the Process Failed Exception
        /// </summary>
        /// <param name="exitCode">The process exit code</param>
        /// <param name="jdeRequest">The request sent for processing</param>
        /// <param name="jdeResponse">The response generated after processing</param>
        public JDEProcessFailedException(JDEXmlInteropProcessExitCodes exitCode, JDEXmlOperation jdeRequest, JDEXmlOperation jdeResponse): base(string.Format("Request {0} exited with code {1} ({2})", jdeRequest.UniqueKey, exitCode.ToString(), Enum.GetName(typeof(JDEXmlInteropProcessExitCodes), exitCode)))
        {
            ExitCode = exitCode;
            JDEXmlRequest = jdeRequest;
            JDEXmlRequestFilename = "";
            JDEXmlResponse = jdeResponse;
            JDEXmlResponseFilename = "";
        }

        /// <summary>
        /// Initializes the Process Failed Exception
        /// </summary>
        /// <param name="exitCode">The process exit code</param>
        /// <param name="jdeRequest">The request sent for processing</param>
        /// <param name="jdeRequestFilename">The path for the request xml file</param>
        /// <param name="jdeResponse">The response generated after processing</param>
        public JDEProcessFailedException(JDEXmlInteropProcessExitCodes exitCode, JDEXmlRequestCallMethod jdeRequest, string jdeRequestFilename, JDEXmlResponseCallMethod jdeResponse): this(exitCode, jdeRequest, jdeResponse)
        {
            JDEXmlRequestFilename = jdeRequestFilename;
        }

        /// <summary>
        /// Initializes the Process Failed Exception
        /// </summary>
        /// <param name="exitCode">The process exit code</param>
        /// <param name="jdeRequest">The request sent for processing</param>
        /// <param name="jdeRequestFilename">The path for the request xml file</param>
        /// <param name="jdeResponse">The response generated after processing</param>
        /// <param name="jdeResponseFilename">The path for the request xml file</param>
        public JDEProcessFailedException(JDEXmlInteropProcessExitCodes exitCode, JDEXmlRequestCallMethod jdeRequest, string jdeRequestFilename, JDEXmlResponseCallMethod jdeResponse, string jdeResponseFilename): this(exitCode, jdeRequest, jdeResponse)
        {
            JDEXmlRequestFilename = jdeRequestFilename;
            JDEXmlResponseFilename = jdeResponseFilename;
        }

    }
}
