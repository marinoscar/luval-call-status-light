using Microsoft.Extensions.Logging;

namespace Luval.StatusLight.Core
{
    /// <summary>
    /// Provides the methods to control the status light based on the device events
    /// </summary>
    public interface IStatusController
    {
        /// <summary>
        /// Gets the <see cref="IDeviceStatusManager"/>
        /// </summary>
        IDeviceStatusManager DeviceStatusManager { get; }

        /// <summary>
        /// Gets the <see cref="ILightController"/>
        /// </summary>
        ILightController LightController { get; }

        /// <inheritdoc/>
        void Dispose();

        /// <summary>
        /// Starts the operation of the status light
        /// </summary>
        void Start();
    }
}