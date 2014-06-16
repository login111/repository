using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using CheckerApp.Checks;


namespace CheckerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList checkList = new ArrayList();
            checkList.Add(new CheckerTask(new DBCheck(),10));
            checkList.Add(new CheckerTask(new CertificateCheck(), 5));

            CheckerAggregator checkAggr = new CheckerAggregator(checkList);
            checkAggr.Run();
        }
    }
}
