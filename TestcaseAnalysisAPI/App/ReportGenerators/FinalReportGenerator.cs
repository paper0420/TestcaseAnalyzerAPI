using IronXL;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseAnalysisAPI.App.ReportGenerators
{
    internal class FinalReportGenerator
    {
        public static void GenerateReport(SpecParameters baseSpec, string reportType)
        {
            if (reportType == "HV")
            {
                int endRowL1 = WriteTestCases(baseSpec, "L1", "FuSi", 21);
                return;
            }

            //int endRowL3 = WriteTestCases(baseSpec,"L3", "Functional",21);           
            //int endRowL2 = WriteTestCases(baseSpec, "L2", "FuSi", endRowL1);
        }

        private static int WriteTestCases(SpecParameters baseSpec, string Type, string workSheetName, int startRow)
        {
            //var workbook = WorkBook.Load(@"SystemTestReport.xlsm");
            //var worksheet = workbook.GetWorkSheet(workSheetName);
            int currentRowFunctionSheet = startRow;
            int currentRowFuSiSheet = startRow;

            foreach (var htmlTC in baseSpec.HtmlDatas)
            {

                //foreach (var specTC in baseSpec.TestCases)
                {
                    var specTC = baseSpec.TestCasesByID.ContainsKey(htmlTC.ID)
                        ? baseSpec.TestCasesByID[htmlTC.ID]
                        : null;

                    if (specTC == null)
                    {
                        continue;
                    }

                    //if (specTC.ID == htmlTC.ID)
                    {
                        if (specTC.Type == Type)
                        {
                            foreach (var req in specTC.RequirementIDs)
                            {
                                var isNumeric = int.TryParse(req, out int n);
                                if (isNumeric)
                                {
                                    var klhID = baseSpec.CurrentRequirementsByID.ContainsKey(req)
                                        ? baseSpec.CurrentRequirementsByID[req]
                                        : null;

                                    if (klhID == null)
                                    {
                                        continue;
                                    }

                                    if(klhID.FusaType?.Contains("ASIL", "QM", "n.a.", "SR") == true)
                                    {
                                        var workbook = WorkBook.Load(@"SystemTestReport.xlsm");
                                        var worksheet = workbook.GetWorkSheet("FuSi");
                                        WriteRow(currentRowFuSiSheet, htmlTC, specTC, req, worksheet);

                                        currentRowFuSiSheet++;
                                        workbook.Save();


                                    }
                                    else
                                    {
                                        var workbook = WorkBook.Load(@"SystemTestReport.xlsm");
                                        var worksheet = workbook.GetWorkSheet("Functional");
                                        WriteRow(currentRowFunctionSheet, htmlTC, specTC, req, worksheet);

                                        currentRowFunctionSheet++;
                                        workbook.Save();

                                    }

                                }

                            }

                        }


                    }
                }
            }
            
            return currentRowFuSiSheet;
        }

        private static void WriteRow(int currentRow, HtmlData htmlTC, TestCaseOnlyExecutedItem specTC, string req, WorkSheet worksheet)
        {
            worksheet[$"H{currentRow}"].Value = htmlTC.ID;
            worksheet[$"R{currentRow}"].Value = htmlTC.TotalTestResult;
            worksheet[$"U{currentRow}"].Value = htmlTC.NumberOfPassed;
            worksheet[$"W{currentRow}"].Value = htmlTC.NumberOfFailed;
            worksheet[$"X{currentRow}"].Value = htmlTC.NumberOfNotExecuted;

            worksheet[$"B{currentRow}"].Value = specTC.ItemClass1;
            worksheet[$"C{currentRow}"].Value = specTC.ItemClass2;
            worksheet[$"D{currentRow}"].Value = specTC.ItemClass3;
            worksheet[$"I{currentRow}"].Value = specTC.Objective;
            worksheet[$"J{currentRow}"].Value = specTC.Type;

            worksheet[$"K{currentRow}"].Value = req;
            worksheet[$"M{currentRow}"].Value = req;
        }
    }
}
