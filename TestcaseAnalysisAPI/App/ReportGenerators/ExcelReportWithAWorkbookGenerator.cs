using IronXL;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestCaseAnalysisAPI.App.ReportGenerators
{
    public static class ExcelReportWithAWorkbookGenerator
    {
        public static void GenerateTestCaseAndRequirment(SpecParameters spec)
        {
            Directory.CreateDirectory("ExcelReportwithAWorkBook");
            WorkBook xlsxWorkbook2 = WorkBook.Create(ExcelFileFormat.XLSX);


            List<string> testCaseID = new List<string>();

            foreach (var testCase in spec.TestCases)
            {

                if (testCase.ID != null)
                {
                    if (!testCaseID.Contains(testCase.ID))
                    {
                        WorkSheet xlsSheet2 = xlsxWorkbook2.CreateWorkSheet($"{testCase.ID}");

                        //Console.WriteLine(xlsSheet2.Name);

                        TestcasesAndRequirementExcelGenerator.CreateTestCaseExcel(spec.CurrentRequirements, testCase, xlsSheet2);

                    }

                }

                testCaseID.Add(testCase.ID);

            }

            xlsxWorkbook2.SaveAs("ExcelReportwithAWorkBook/TestCaseAndRequirement.xlsx");

        }
    }
}
    
