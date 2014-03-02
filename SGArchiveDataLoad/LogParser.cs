using MSUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class LogParser
    {
        public ILogRecordset extractRawJson(String fileName)
        {
            LogQueryClass logQuery = new LogQueryClassClass();
            MSUtil.COMCSVInputContextClassClass inputFormat = new COMCSVInputContextClassClass();
            //C:\\Users\\jthomas\\Desktop\\SendGrid\\11_27-12_3\\11_15-11_18Output_30.csv' ";
            
            
            String strQuery = @"SELECT _raw FROM '" + fileName + "'";
            ILogRecordset results = logQuery.Execute(strQuery, inputFormat);
            return results;
        }
    }
}
