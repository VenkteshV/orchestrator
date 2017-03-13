using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace orchestrator.Models
{
    /// <summary>
    /// Services model class
    /// </summary>
    public class Services
    {
        /// <summary>
        /// List of all services to be executed
        /// </summary>
        [YamlMember(Alias = "services")]
        public List<Service> ListOfServices { get; set; }


        /// <summary>
        /// A function to find the service from list of services
        /// </summary>
        /// <param name="key">Key of the service to be fetched</param>
        /// <returns>Service object</returns>
        public Service GetServiceByKey(string key)
        {
            foreach (Service service in ListOfServices)
            {
                if (service.Key.Equals(key))
                {
                    return service;
                }
            }
            return null;
        }
    }
}
