﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseAnalysisAPI.App
{
    public static class FileNames
    {
        private static readonly string InputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Input");
        public static readonly string OutputFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Output");

        public const string KlhFile = "KLH11_BL1.xlsx";
        public static readonly string TestSpecFile = Path.GetFullPath("Specification_V05.xlsx", InputFolder);
        public static readonly string ReportTemplateFile = Path.GetFullPath("Template.xlsx", InputFolder);
        public static readonly string HtmlReportL1Folder = Path.GetFullPath("HtmlReportL1", InputFolder);
        public static readonly string HtmlReportL2Folder = Path.GetFullPath("HtmlReportL2", InputFolder);
        public static readonly string HtmlReportL3Folder = Path.GetFullPath("HtmlReportL3", InputFolder);


    }

}
