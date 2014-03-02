using MSUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGArchiveDataLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            LogParser logParser = new LogParser();

            //String fileName = "C:\\Users\\jthomas\\Desktop\\SendGrid\\11_27-12_3\\11_15-11_18Output_30.csv ";
            Console.WriteLine("Enter Filename");
            String fileName = Console.ReadLine();
            ILogRecordset results = logParser.extractRawJson(fileName);

            DataAccess da = new DataAccess();
            da.insertData(results);
        }
    }
}
