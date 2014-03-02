using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class DropEvent:IEvent
    {
        public String parseString(JObject obj, String commString)
        {
            StringBuilder sb = new StringBuilder(commString);
            sb.Append(",\"sg_event_id\":\"" + (string)obj["sg_event_id"] + "\",\"sg_message_id\":\"" + (string)obj["sg_message_id"] + "\",\"smtp-id\":\"" + (string)obj["smtp-id"] + "\",\"reason\":\"" + (string)obj["reason"] + "\"}");
            return sb.ToString();
        }
    }
}
