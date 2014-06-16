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
        ArrayList taskList;

        public CheckerAggregator() { }
        public CheckerAggregator(ArrayList checkList_)
        {
            this.checkList = checkList_;
            taskList = new ArrayList();
        }


        public void Run()
        {
                foreach (ICheck check in checkList)
                {
                    CheckerTask checkerTask = new CheckerTask(check);
                    taskList.Add(checkerTask);
                    checkerTask.Start();
                }


                while (true)
                {                
                   foreach (CheckerTask task in taskList)
                    {
                        if (task.IsCompleted())
                        {
                            CheckResult res = task.Result();
                            Console.WriteLine("Status : " + res.code + " Message : " + res.message);
                            task.Restart();
                        }
                    }
                }
        }

    }
}
