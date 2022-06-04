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
    public class DeviceStatusEventArgs : EventArgs
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public DeviceStatusEventArgs(bool camStatus, bool micStatus)
        {
            CameraInUse = camStatus;
            MicrophoneInUse = micStatus;
        }

        /// <summary>
        /// Gets if the camera is in use
        /// </summary>
        public bool CameraInUse { get; private set; }

        /// <summary>
        /// Gets if the microphone is in use
        /// </summary>
        public bool MicrophoneInUse { get; private set;  }
    }
}
