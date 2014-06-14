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

        public CheckResult Check()
        {
            CheckResult result = new CheckResult();
            result.code = CheckResult.StatusCode.OK;
            result.message = "Connected to DB";

            
                SqlConnection connection = new SqlConnection("Data Source=TCOMPUTER;Initial Catalog=testDB;Integrated Security=True");
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
