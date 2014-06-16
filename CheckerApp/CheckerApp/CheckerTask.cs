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
        
        public CheckerTask(ICheck check_)
        {
            this.check = check_;
        }

        public void Start()
        {
            task = new Task<CheckResult>(new Func<CheckResult>(check.Check));
            task.Start();
        }

        public void Restart()
        {
                if (this.IsCompleted())
                {
                    task.Dispose();
                    task = new Task<CheckResult>(new Func<CheckResult>(check.Check));
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
