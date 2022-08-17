using IronXL;
using System.Collections.Generic;
using System.Linq;

namespace TestCaseAnalysisAPI.App
{
    public class SpecParameters
    {
        public SpecParameters(
          List<Requirement> currentRequirments = null,
          List<Requirement> newRequirements = null,
          List<TestCaseOnlyExecutedItem> testCases = null,
          List<TestCase> panaTestCases = null,
          WorkSheet xlsSheet = null,
          List<string> allTestCaseIDs = null,
          List<HtmlData> htmlDatas = null)
        {
            this.CurrentRequirements = currentRequirments;
            this.NewRequirements = newRequirements;
            this.TestCases = testCases;
            this.TestCasesByID = testCases.ToDictionary(testCase => testCase.ID);

            this.CurrentRequirementsByID = currentRequirments
                .Where(t => t.ID != null)
                .ToDictionary(curRequirement => curRequirement.ID);

            this.XlsSheet = xlsSheet;
            this.allTestCaseIDs = allTestCaseIDs;
            this.HtmlDatas = htmlDatas;

        }

        public List<Requirement> CurrentRequirements { get; set; }
        public List<Requirement> NewRequirements { get; set; }
        public List<TestCaseOnlyExecutedItem> TestCases { get; set; }
        public Dictionary<string, TestCaseOnlyExecutedItem> TestCasesByID { get; set; }
        public Dictionary<string, Requirement> CurrentRequirementsByID { get; set; }
 

        public WorkSheet XlsSheet { get; set; }


        public List<string> allTestCaseIDs { get; set; }
        public List<HtmlData> HtmlDatas { get; set; }
    }
}
