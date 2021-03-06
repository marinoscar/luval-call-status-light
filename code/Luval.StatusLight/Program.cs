using Luval.StatusLight.Core;

namespace Luval.StatusLight
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            var context = GetAppContext(args);
            context.Start();
            Application.Run(context);
        }

        static LuvalApplicationContext GetAppContext(string[] args)
        {
            if (args == null || !args.Any()) throw new ArgumentNullException("args");
            var consoleArgs = new ConsoleSwitches(args);
            return new LuvalApplicationContext(
                new StatusController(
                    new DeviceStatusManager(
                        new DeviceStatusParams(Convert.ToDouble(consoleArgs.IntervalDuration))),
                    new LightController(consoleArgs.ApiKey), 
                    new DebugLogger()));

        }
    }
}