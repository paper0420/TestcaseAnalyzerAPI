﻿using System;
using System.Collections.Generic;
using System.IO;

namespace TestCaseAnalysisAPI.App.ReportGenerators
{
    public class HtmlReportGenerator : IReportGenerator
    {
        public void GenerateReport(List<TestCase> testCases, List<Requirement> requirements)
        {
            Directory.CreateDirectory("report");

            string testcaseMenu = null;

            for (int i = 0; i < testCases.Count; i++)
            {
                TestCase testCase = testCases[i];
                if (testCase.ID != null)
                {
                    testcaseMenu += $"<a href='{testCase.ID.Replace("#", "")}.html'>{testCase.ID}</a><br>\n";
                }
            }

            foreach (var testCase in testCases)
            {
                if (testCase.ID != null)
                {
                    string testCaseDetail = TestCaseHtmlGenerator.CreateTestCaseHtml(
                        requirements,
                        testCase);

                    File.WriteAllText(
                        $"report/{testCase.ID.Replace("#", "")}.html",
                        testCaseDetail);
                }
            }



            File.WriteAllText("report/index.html", testcaseMenu);
        }
    }
}
