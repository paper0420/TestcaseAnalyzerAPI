﻿using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCaseAnalysisAPI.App
{
    public class Dummy
    {
        public Dummy(IExcelDataReader reader)
        {
            //this.SYR_ID = reader.GetValue(7)?.ToString();
            this.KLH_ID = reader.GetValue(1)?.ToString();

        }

        public string SYR_ID { get; }
        public string KLH_ID { get; }


    }
}
