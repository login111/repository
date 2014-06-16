using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;

namespace CheckerApp
{
    class DBCheck : ICheck
    {

        public CheckResult Check(int delay)
        {
            CheckResult result = new CheckResult();
            result.code = CheckResult.StatusCode.OK;
            result.checkName = "DataBase Check";
            result.message = "Connected to DB";

            for (int i = delay; i > 0; i--)
            {
              //  Console.WriteLine("DBCheck timer : " + i);
                Thread.Sleep(1000);
            }

                SqlConnection connection = new SqlConnection("Data Source=TCOMPUTE;Initial Catalog=testDB;Integrated Security=True");
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    result.code = CheckResult.StatusCode.ERROR;
                    result.message = e.Message;
                }

                return result;
        }

    }
}
