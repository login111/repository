﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckerApp
{
    interface ICheck
    {
        CheckResult Check(int delay);
    }
}
