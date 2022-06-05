using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.StatusLight.Core
{
    /// <summary>
    /// Event arguments for the <see cref="DeviceStatusManager"/>
    /// </summary>
    public class MicrophoneStatusEventArgs
    {
        /// <summary>
        /// Gets if the microphone is in use
        /// </summary>
        public bool MicrophoneInUse { get; private set; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="micStatus"></param>
        public MicrophoneStatusEventArgs(bool micStatus)
        {
            MicrophoneInUse = micStatus;
        }
    }
}
