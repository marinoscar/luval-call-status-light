using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.StatusLight.Core
{
    /// <summary>
    /// Exception when the <see cref="LightController" fails/>
    /// </summary>
    public class LightControllerException : Exception
    {
        /// <inheritdoc/>
        public LightControllerException(string message, Exception innerException) : base(message, innerException)   
        {

        }

        /// <inheritdoc/>
        public LightControllerException(string message) : base(message)
        {

        }

        /// <inheritdoc/>
        public LightControllerException()
        {

        }
    }
}
