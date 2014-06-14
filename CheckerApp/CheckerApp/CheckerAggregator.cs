using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;

namespace CheckerApp
{
    class CheckerAggregator
    {

        ArrayList checkList;

        public CheckerAggregator() { }
        public CheckerAggregator(ArrayList checkList_)
        {
            this.checkList = checkList_;
        }


        public void Run()
        {
            while (true)
            {
                foreach (ICheck check in checkList)
                {
                    Task task = new Task<CheckResult>(new Func<CheckResult>(check.Check));
                    task.Start();
                }


                for (int i = 15; i >= 0; i--)
                {
                    Console.WriteLine(" :" + i);
                    Thread.Sleep(1000);
                }
            }



        }



    }
}
