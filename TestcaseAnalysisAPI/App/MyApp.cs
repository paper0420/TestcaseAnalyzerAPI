using System;
using System.Collections.Generic;
using System.Linq;
using TestcaseAnalysisAPI.App.FileReader;
using TestCaseAnalysisAPI.App.ReportGenerators;
using TestcaseAnalysisAPI.App;

namespace TestCaseAnalysisAPI.App
{
    public class MyApp
    {
        public void RunMyApp(string carLine, string reportType)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var reader = new ExcelReader();
            var userInput = new FinalReportGenerationUI();
            var currentKLHs = reader.ReadFile(FileNames.TestSpecFile, "KLH", 1, (t, y) => new Requirement(t, y)).ToList();
            var safetyGoalKLHs = reader.ReadFile(FileNames.TestSpecFile, "SafetyGoal", 1, (t, y) => new SafetyGoalKLH(t, y)).ToList();
            var executedTestcases = reader.ReadFile(FileNames.TestSpecFile, "Test_Item", 1, (t, y) => new TestCaseOnlyExecutedItem(t, y)).ToList();

            var htmlReports = HtmlReader.ReadHtmlFullReport(userInput.ReportType).ToList();

            var baseSpec = new SpecParameters(
                currentRequirments: currentKLHs,
                testCases: executedTestcases,
                htmlDatas: htmlReports,
                safetyGoalKLHs: safetyGoalKLHs);

            FinalReportGenerator.GenerateReport(baseSpec, userInput.ReportType, userInput.CarLine, userInput.SWRelease);

        }
    }
}
