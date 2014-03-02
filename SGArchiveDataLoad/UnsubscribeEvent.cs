using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class UnsubscribeEvent:IEvent
    {
        public String parseString(JObject obj, String commString)
        {
            return commString;
        }
    }
}
