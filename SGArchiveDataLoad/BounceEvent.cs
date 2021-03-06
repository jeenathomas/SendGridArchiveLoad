﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class BounceEvent:IEvent
    {
        public String parseString(JObject obj, String commString)
        {
            StringBuilder sb = new StringBuilder(commString);
            sb.Append(",\"smtp-id\":\"" + (string)obj["smtp-id"] + "\",\"sg_event_id\":\"" + (string)obj["sg_event_id"] + "\",\"sg_message_id\":\"" + (string)obj["sg_message_id"] + "\",\"status\":\"" + (string)obj["status"] + "\",\"reason\":\"" + (string)obj["reason"] + "\",\"type\":\"" + (string)obj["type"] + "\"}");
            return sb.ToString();
        }
    }
}
