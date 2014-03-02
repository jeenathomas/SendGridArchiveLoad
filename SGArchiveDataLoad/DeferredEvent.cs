using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class DeferredEvent:IEvent
    {
        public String parseString(JObject obj, String commString)
        {
            StringBuilder sb = new StringBuilder(commString);
            sb.Append(",\"smtp-id\":\"" + (string)obj["smtp-id"] + "\",\"sg_event_id\":\"" + (string)obj["sg_event_id"] + "\",\"response\":\"" + (string)obj["response"] + "\",\"attempt\":\"" + (string)obj["attempt"] + "\"}");
            return sb.ToString();
        }
    }
}
