using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckerApp
{
    class DBCheck : ICheck
    {

        public CheckResult Check()
        {
            CheckResult result = new CheckResult();
            result.code = CheckResult.StatusCode.OK;
            result.message = "connected to DB";
            Console.WriteLine("Status : " + result.code + " Message : " + result.message);
            return result;
        }
    }
}
