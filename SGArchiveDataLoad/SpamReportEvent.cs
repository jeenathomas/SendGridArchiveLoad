using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class SpamReportEvent:IEvent
    {
        public String parseString(JObject obj, String commString)
        {
            StringBuilder sb = new StringBuilder(commString);
            sb.Append(",\"sg_event_id\":\"" + (string)obj["sg_event_id"] + "\",\"sg_message_id\":\"" + (string)obj["sg_message_id"] + "\"}");
            return sb.ToString();
        }
    }
}
