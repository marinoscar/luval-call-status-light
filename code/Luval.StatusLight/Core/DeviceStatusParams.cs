using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.StatusLight.Core
{

    /// <summary>
    /// Provides the parameters to monitor the devices
    /// </summary>
    public class DeviceStatusParams
    {
        /// <summary>
        /// Gets or sets the number of milliseconds it will wait
        /// to inspect on the status of the devices
        /// </summary>
        public double TestIntervalInMs { get; set; }
        
        /// <summary>
        /// Gets or sets what the initial status would be for the devices.
        /// True for In Use and False of Not On Use
        /// </summary>
        public bool InitialStatus { get; set; }

        /// <summary>
        /// Creates a new instance of the class
        /// </summary>
        /// <param name="testIntervalInMs">Duration of the test interval</param>
        public DeviceStatusParams(double testIntervalInMs)
        {
            TestIntervalInMs = testIntervalInMs;
        }

        /// <summary>
        /// Creates a new instance of the class
        /// </summary>
        public DeviceStatusParams() : this(5000d)
        {

        }
    }
}
