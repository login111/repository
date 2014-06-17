using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;



namespace CheckerApp.Checks
{
    class RAMCheck : ICheck
    {
        public CheckResult Check(int delay)
        {
            Thread.Sleep(delay * 1000);

            CheckResult result = new CheckResult();
            result.checkName = "RAM Check";
            result.code = CheckResult.StatusCode.OK;
            result.message = "";

            try
            {
                ComputerInfo ci = new ComputerInfo();
                double memTotal = Convert.ToDouble(ci.TotalPhysicalMemory);
                memTotal = memTotal / (1024 * 1024);
                int memTotalMb = Convert.ToInt32(memTotal);
                double memAvalible = Convert.ToDouble(ci.AvailablePhysicalMemory);
                memAvalible = memAvalible / (1024 * 1024);
                int memAvalibleMb = Convert.ToInt32(memAvalible);

                double ratio = memAvalible / memTotal * 100;

                if (ratio < 10)
                {
                    result.code = CheckResult.StatusCode.ERROR;
                    result.message = "Low RAM warning" + "\n" +
                                     "Avalible " + memAvalibleMb + " mb of " + memTotalMb + " mb ( " + ratio.ToString("0.00") + "% )";
                }
                else
                {
                    result.code = CheckResult.StatusCode.OK;
                    result.message = "RAM is OK" + "\n" +
                                     "Avalible " + memAvalibleMb + " mb of " + memTotalMb + " mb ( " + ratio.ToString("0.00") + "% )";
                }

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
