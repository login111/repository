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
        ISender sender;

        public CheckerAggregator() { }
        public CheckerAggregator(ArrayList checkList_,ISender sender_)
        {
            this.checkTaskList = checkList_;
            this.sender = sender_;
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
                            String msg = "Check : "+res.checkName + "\n" +
                                         "Status : " + res.code + "\n"+
                                         "Message : " + res.message;
                            Console.WriteLine(msg);

                            if (res.code == CheckResult.StatusCode.ERROR)
                            {
                                sender.Sending(DateTime.Now.ToString() + " : " + msg);                            
                            }

                            Console.WriteLine();
                            task.Restart();
                        }
                    }
                }
        }

    }
}
