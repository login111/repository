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
                    Task task = new Task<CheckResult>(new Func<CheckResult>(check.Check));
                    taskList.Add(task);
                    task.Start();
                }

                Task[] taskArr = (Task[]) taskList.ToArray(typeof(Task));
                Task.WaitAll(taskArr);

                foreach (Task<CheckResult> task in taskList)
                {
                    CheckResult res = task.Result;
                    Console.WriteLine("Status : " + res.code + " Message : " + res.message);                
                }
        }



    }
}
