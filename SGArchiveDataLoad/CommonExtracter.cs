using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class CommonExtracter
    {
        public String getCommonAttributes(JObject obj)
        {
            var uniqueArgs = obj["unique_args"];
            String commString = "{\"email\":\"" + (string)obj["email"] + "\",\"timestamp\":\"" + (string)obj["timestamp"] + "\",\"event\":\"" + (string)obj["event"] + "\",\"category\":\"" + (string)obj["category"] + "\",\"unique_args\":\"" + uniqueArgs + "\",\"newsletter\":\"" + (string)obj["newsletter"] + "\"";
            return commString;
        }
    }
}
