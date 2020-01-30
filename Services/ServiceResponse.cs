using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    [Serializable]
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public ServiceResponse() { }
        public IList<T> List { get; set; }

        [JsonProperty]
        public T Entity { get; set; }

        public int Count { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
