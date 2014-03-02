using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class ClickEvent:IEvent
    {
        public String parseString(JObject obj, String commString)
        {
            StringBuilder sb = new StringBuilder(commString);
            sb.Append(",\"ip\":\"" + (string)obj["ip"] + "\",\"useragent\":\"" + (string)obj["useragent"] + "\",\"url\":\"" + (string)obj["url"] + "\"}");
            return sb.ToString();
        }
    }
}
