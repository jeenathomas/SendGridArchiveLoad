using MSUtil;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class DataAccess
    {
        string jsonString;
        string eventString;
        CommonParser cp = new CommonParser();

        private String getConnectionString()
        {
            return SQLConstants.CONN_STRING;
        }




        private DataTable insertIntoDataTable(ILogRecordset results)
        {
            //Console.WriteLine("Inside Insert Data");
            DataTable dt = new DataTable("RawJsonData");

            dt.Columns.Add("RawJson", typeof(String));
            dt.Columns.Add("Timestamp", typeof(DateTime));

            while (!results.atEnd())
            {
                String res = results.getRecord().getValue(0).ToString();
                

                var parts = res.Split(new char[] { '{' }, 2);
                jsonString = "{" + parts[1];

                /*
                JObject obj = JObject.Parse(jsonString);
                string eventType = (string)obj["event"];
               // var uniqueArgs = obj["unique_args"];


                
                switch (eventType)
                {
                    case EventCategory.OPEN: eventString = cp.getJsonString(obj, new OpenEvent());
                        break;
                    case EventCategory.BOUNCE: eventString = cp.getJsonString(obj, new BounceEvent());
                        break;
                    case EventCategory.CLICK: eventString = cp.getJsonString(obj, new ClickEvent());
                        break;
                    case EventCategory.DEFERRED: eventString = cp.getJsonString(obj, new DeferredEvent());
                        break;
                    case EventCategory.DELIVERED: eventString = cp.getJsonString(obj, new DeliveredEvent());
                        break;
                    case EventCategory.DROP: eventString = cp.getJsonString(obj, new DropEvent());
                        break;
                    case EventCategory.PROCESSED: eventString = cp.getJsonString(obj, new ProcessedEvent());
                        break;
                    case EventCategory.SPAMREPORT: eventString = cp.getJsonString(obj, new SpamReportEvent());
                        break;
                    case EventCategory.UNSUBSCRIBE: eventString = cp.getJsonString(obj, new UnsubscribeEvent());
                        break;
                }*/

                dt.Rows.Add(jsonString, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                results.moveNext();
            }
            return dt;
        }




        public void insertData(ILogRecordset results)
        {

            DataTable dt = insertIntoDataTable(results);
            string connectionString = getConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                using (SqlBulkCopy sbc = new SqlBulkCopy(connection))
                {
                    sbc.DestinationTableName = "dbo.RawJsonTest";
                    sbc.ColumnMappings.Add("RawJson", "RawJson");
                    sbc.ColumnMappings.Add("Timestamp", "TimeStamp");
                    sbc.BulkCopyTimeout = 0;
                    sbc.WriteToServer(dt);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
