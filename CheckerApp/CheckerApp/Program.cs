using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CheckerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList checkList = new ArrayList();
            checkList.Add(new DBCheck());

            CheckerAggregator checkAggr = new CheckerAggregator(checkList);
            checkAggr.Run();
        }
    }
}
