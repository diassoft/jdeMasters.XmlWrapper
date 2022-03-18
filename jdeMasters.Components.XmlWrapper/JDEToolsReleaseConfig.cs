using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace jdeMasters.Components.XmlWrapper
{
    /// <summary>
    /// Represents a tools release configuration
    /// </summary>
    public sealed class JDEToolsReleaseConfig
    {
        /// <summary>
        /// Defines whether the configuration is the most recent active or not
        /// </summary>
        [XmlAttribute("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Function to be called by the serializer to define whether to serialize the <see cref="Active"/> property
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeActive()
        {
            return Active;
        }

        /// <summary>
        /// The tools release number
        /// </summary>
        [XmlAttribute("number")]
        public string ToolsRelease { get; set; }

        /// <summary>
        /// The interoperability program type.
        /// It can be a Win32 application or a Java Application.
        /// </summary>
        [XmlAttribute("programType")]
        public JDEToolsReleaseConfigProgramTypes ProgramType { get; set; }

        /// <summary>
        /// The Full Path of the Executable Program
        /// </summary>
        [XmlElement("appExecutablePath")]
        public string ExecutablePath { get; set; }

        /// <summary>
        /// The Path where Java is installed.
        /// It is necessary when the Tools Release application is a Java Application.
        /// Each tools release must have the java path configured, because sometimes the java version can be different.
        /// </summary>
        [XmlElement("javaPath")]
        [DefaultValue("")]
        public string JavaPath { get; set; }

        /// <summary>
        /// Defines whether the JavaPath property should be serialized or not
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeJavaPath()
        {
            return ((JavaPath != "") && (ProgramType == JDEToolsReleaseConfigProgramTypes.Java));
        }

        /// <summary>
        /// Initializes a new instance of a JDE Tools Release Configuration
        /// </summary>
        public JDEToolsReleaseConfig()
        {
            ToolsRelease = "";
            Active = false;
            ExecutablePath = "";
            ProgramType = JDEToolsReleaseConfigProgramTypes.Win32;
            JavaPath = "";
        }
        
        [XmlIgnore]
        private string _callingSyntax;

        /// <summary>
        /// Returns the executable that must be called to call XML Dispatch Services.
        /// If the executable is a Java Program, it will append the JRE folder and the "java" call before the Executable Path.
        /// </summary>
        [XmlIgnore]
        public string CallingSyntax
        {
            get
            {
                // If there is a valid Calling Syntax already, then return it
                if (_callingSyntax != "") return _callingSyntax;

                // There is no calling syntax, then build it
                if (ShouldSerializeJavaPath())
                {
                    // Add the \\ if necessary
                    _callingSyntax = string.Format("{0}{1}java {2}", JavaPath, JavaPath.EndsWith("\\") ? "" : "\\", ExecutablePath);
                }
                else
                {
                    // Calling Syntax is just the Executable Path
                    _callingSyntax = string.Format("{0}", ExecutablePath);
                }

                // Return the rebuilt Calling Syntax
                return _callingSyntax;
            }
        }
    }

    /// <summary>
    /// Types of Tools Release configuration
    /// </summary>
    public enum JDEToolsReleaseConfigProgramTypes : int
    {
        /// <summary>
        /// The program type is a Win32 Console Application
        /// </summary>
        [XmlEnum("win32")]
        Win32 = 0,
        /// <summary>
        /// The program type is a Java Console Application. Java must be installed in order to run it.
        /// </summary>
        [XmlEnum("java")]
        Java = 1
    }
}
