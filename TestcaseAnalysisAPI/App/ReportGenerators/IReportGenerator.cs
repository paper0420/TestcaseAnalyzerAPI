using System.Collections.Generic;

namespace TestCaseAnalysisAPI.App.ReportGenerators
{
    public interface IReportGenerator
    {
        void GenerateReport(List<TestCase> testCases, List<Requirement> requirements);

    }
}
