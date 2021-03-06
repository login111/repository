﻿using System;
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
            ISender emailSender = new EmailSender();
            ArrayList checkList = new ArrayList();
            checkList.Add(new CheckerTask(new DBCheck(),10));
            checkList.Add(new CheckerTask(new CertificateCheck(), 5));
            checkList.Add(new CheckerTask(new RAMCheck(), 1));
            checkList.Add(new CheckerTask(new CPUCheck(), 1));


            CheckerAggregator checkAggr = new CheckerAggregator(checkList,emailSender);
            checkAggr.Run();
        }
    }
}
