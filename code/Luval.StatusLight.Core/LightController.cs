using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luval.StatusLight.Core
{
    /// <summary>
    /// Provides the methods to control the status light
    /// </summary>
    public class LightController
    {

        private string _key;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="apiKey">The API ket to use</param>
        public LightController(string apiKey)
        {
            _key = apiKey;
        }

        /// <summary>
        /// Turns on the light
        /// </summary>
        /// <exception cref="LightControllerException">If the api call fails</exception>
        public void TurnOn()
        {
            MakeCall(_key, "status_on");
        }

        /// <summary>
        /// Turns off the light
        /// </summary>
        /// <exception cref="LightControllerException">If the api call fails</exception>
        public void TurnOff()
        {
            MakeCall(_key, "status_off");
        }

        private void MakeCall(string key, string eventName)
        {
            HttpResponseMessage response = null;
            var client = new HttpClient();
            try
            {
                response = client.GetAsync(string.Format("https://maker.ifttt.com/trigger/{0}/with/key/{1}"
                        , eventName, key)).Result;
            }
            catch (Exception ex)
            {
                throw new LightControllerException("Unable to complete request", ex);
            }

            if(response == null) throw new LightControllerException("Unable to get a response");
            if(response.StatusCode != System.Net.HttpStatusCode.OK) throw new LightControllerException(string.Format("Failed with status {0} and message {1}", response.StatusCode, Convert.ToString(response.Content)));
        }
    }
}
