using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace CheckerApp.Checks
{
    class CPUCheck : ICheck
    {
        public CheckResult Check(int delay)
        {
            if (delay > 0) delay -= 1;
            Thread.Sleep(delay * 1000);

            CheckResult result = new CheckResult();
            result.checkName = "CPU Check";
            result.code = CheckResult.StatusCode.OK;
            result.message = "";

            try
            {
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue();
                Thread.Sleep(1000);

                float prcent = cpuCounter.NextValue();
                if (prcent > 90)
                {
                    result.code = CheckResult.StatusCode.ERROR;
                    result.message = "Warning high usage of CPU ( " + prcent.ToString("0.00") + "% )";
                }
                else
                {
                    result.code = CheckResult.StatusCode.OK;
                    result.message = "CPU is OK (" + prcent.ToString("0.00") + " %) ";
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
