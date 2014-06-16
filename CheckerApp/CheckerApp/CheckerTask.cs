using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CheckerApp
{
    class CheckerTask
    {
        private ICheck check;
        private Task<CheckResult> task;
        private int secToWait;

        
        public CheckerTask(ICheck check_,int sec)
        {
            this.check = check_;
            this.secToWait = sec;
        }

        public void Start()
        {
            task = new Task<CheckResult>(() => check.Check(0));
            task.Start();
        }

        public void Restart()
        {
                if (this.IsCompleted())
                {
                    task.Dispose();
                    task = new Task<CheckResult>(() => check.Check(secToWait));
                    task.Start();
                }
        }

        public bool IsCompleted()
        {
            return task.IsCompleted;
        }

        public CheckResult Result()
        {
            return task.Result;
        }

    }
}
