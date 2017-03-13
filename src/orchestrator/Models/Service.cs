using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace orchestrator.Models
{
    public class Service
    {
        /// <summary>
        /// Name of the service
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url endpoint of the service
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Key for the service
        /// </summary>
        public string Key { get; set; }

     

        /// <summary>
        /// JSON response the service
        /// </summary>
        public JObject Response { get; set; }

        /// <summary>
        /// Successfull execution status of the service
        /// </summary>
        public bool Success { get; set; }
    }
}
