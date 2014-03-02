using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class CommonParser
    {
        public String getJsonString(JObject obj,IEvent eventType)
        {
            String partialString = new CommonExtracter().getCommonAttributes(obj);
            String jsonString = eventType.parseString(obj, partialString);
            return jsonString;

        }
    }
}
