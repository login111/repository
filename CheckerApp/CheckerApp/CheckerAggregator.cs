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
        ArrayList checkTaskList;

        public CheckerAggregator() { }
        public CheckerAggregator(ArrayList checkList_)
        {
            this.checkTaskList = checkList_;
        }


        public void Run()
        {
            foreach (CheckerTask task in checkTaskList)
                {
                    task.Start();
                }


                while (true)
                {
                    foreach (CheckerTask task in checkTaskList)
                    {
                        if (task.IsCompleted())
                        {
                            CheckResult res = task.Result();
                            Console.WriteLine("Check : "+res.checkName + "\n" +
                                              "Status : " + res.code + "\n"+
                                              "Message : " + res.message);
                            Console.WriteLine();
                            task.Restart();
                        }
                    }
                }
        }

    }
}
