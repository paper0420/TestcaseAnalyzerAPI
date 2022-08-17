using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCaseAnalysisAPI.App
{
    public class TestCaseExcelGenerator
    {
      

        public static void CreateTestCaseExcel(
            List<Requirement> requirements,
            TestCase testCase,
            WorkSheet xlsSheet)
        {
            GenerateRequirementsExcel(
                requirements,
                testCase,
                xlsSheet);

            xlsSheet["A1"].Value = "Test Case ID";
            xlsSheet["C1"].Value = $"{testCase.ID}";
            xlsSheet["D1"].Value = $"[{testCase.TotalTestResults}],[{testCase.TestResultFuSi}],[{testCase.TestResultFunctional}]";
            xlsSheet["A2"].Value = "Test Objective";
            xlsSheet["C2"].Value = $"{testCase.Objective}";
            xlsSheet["D2"].Value = $"[{testCase.ItemClass1}],[{testCase.ItemClass2}],[{testCase.ItemClass3}]";
            xlsSheet["A3"].Value = "Requirements";
        }

        private static void GenerateRequirementsExcel(List<Requirement> requirements, TestCase testCase, WorkSheet xlsSheet)
        {
            var testCaseRequirements = requirements
                .Where(t => testCase.RequirementIDs.Any(c => c == t.ID))
                .ToList();

            int row = 5;
            foreach (var requirement in testCaseRequirements)
            {


                //    xlsSheet[$"A{Row}"].Value = $"{testCase.ID}";
                //    xlsSheet[$"B{Row}"].Value = $"{testCase.Objective}";
                xlsSheet[$"C{row}"].Value = $"{requirement.ID},[{requirement.changeStatus}],[{requirement.panaStatus}]";
                xlsSheet[$"D{row}"].Value = $"{requirement.Objective}";
                //xlsSheet[$"E{Row}"].Value = $"{string.Join(", ", requirement.EpicIDs)}";
                row++;
            }


        }

 




    }
}
