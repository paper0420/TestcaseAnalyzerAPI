using System;
using System.Collections.Generic;
using System.Linq;
using TestcaseAnalysisAPI.App.FileReader;
using TestCaseAnalysisAPI.App.ReportGenerators;

namespace TestCaseAnalysisAPI.App
{
    public class MyApp
    {
        public string RunMyApp(string newFile, string currentFile, string type)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var reader = new ExcelReader();

       
            var currentKLH = reader.ReadFile(FileNames.KlhFile, "KLH_BL11.1", 1, (t, y) => new Requirement(t, y)).ToList();
            var executedTestcases = reader.ReadFile(FileNames.TestSpecFile, "Test_Item", 1, (t, y) => new TestCaseOnlyExecutedItem(t, y)).ToList();
            var htmlReports = HtmlReader.ReadHtmlFullReport().ToList();

            var baseSpec = new SpecParameters(
              currentRequirments: currentKLH,
              testCases: executedTestcases,
              htmlDatas: htmlReports);
            
            FinalReportGenerator.GenerateReport(baseSpec, "HV");


            return "No data";


        }
    }
}
