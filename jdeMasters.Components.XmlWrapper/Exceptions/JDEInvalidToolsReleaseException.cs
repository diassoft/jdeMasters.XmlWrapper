using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdeMasters.Components.XmlWrapper.Exceptions
{
    /// <summary>
    /// Represents an error that occurs when the tools release is not configured on the JDE Service.
    /// </summary>
    public class JDEInvalidToolsReleaseException: Exception
    {
        private string _toolsRelease;

        /// <summary>
        /// The name of the tools release
        /// </summary>
        public string ToolsRelease { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JDEInvalidToolsReleaseException"/>
        /// </summary>
        public JDEInvalidToolsReleaseException(): base("Invalid tools release")
        {
            _toolsRelease = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JDEInvalidToolsReleaseException"/>
        /// </summary>
        /// <param name="message">The error message</param>
        public JDEInvalidToolsReleaseException(string message): base(message)
        {
            _toolsRelease = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JDEInvalidToolsReleaseException"/>
        /// </summary>
        /// <param name="innerException">The inner exception</param>
        /// <param name="message">The error message</param>
        public JDEInvalidToolsReleaseException(string message, Exception innerException) : base(message, innerException)
        {
            _toolsRelease = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JDEInvalidToolsReleaseException"/>
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="toolsRelease">The tools release</param>
        public JDEInvalidToolsReleaseException(string message, string toolsRelease) : base(message)
        {
            _toolsRelease = toolsRelease;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JDEInvalidToolsReleaseException"/>
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="toolsRelease">The tools release</param>
        /// <param name="innerException">The inner exception</param>
        public JDEInvalidToolsReleaseException(string message, string toolsRelease, Exception innerException) : base(message, innerException)
        {
            _toolsRelease = toolsRelease;
        }

    }
}
