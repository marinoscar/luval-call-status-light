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
    public class CameraStatusEventArgs : EventArgs
    {
        /// <summary>
        /// Gets if the camera is in use
        /// </summary>
        public bool CameraInUse { get; private set; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public CameraStatusEventArgs(bool camStatus)
        {
            CameraInUse = camStatus;
        }
    }
}
