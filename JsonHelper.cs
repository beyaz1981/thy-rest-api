using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIModel.Helper
{
    public class JsonHelper
    {
        public JsonHelper()
        {

        }

        public T JsonToModel<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        public string ModelToJson(object model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public string Model2JsonIgnoreNullValues(object model)
        {
            return JsonConvert.SerializeObject(model, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
