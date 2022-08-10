using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCaseAnalysisAPI.App
{
    public class App
    {
        public string RunMyApp(string newFile, string currentFile)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var reader = new DataFileReader();

            var newKLH = reader.ReadFile(newFile, "Sheet1", 2, t => new Requirement(t)).ToList();
            var currentKLH = reader.ReadFile(currentFile, "KLH_BL10.14", 2, t => new Requirement(t)).ToList();
 
            var baseSpec = new SpecParameters(currentKLH, newKLH);

            RequirementsManager compareBaseline = new RequirementsManager();
            compareBaseline.CompareBaseline(baseSpec);
            //RequirementsManager.FindTestCasesLinked(baseSpec);
            //RequirementsManager.FindENG9TestCasesLinked(baseSpec);
            return compareBaseline.NewRequirements;


        }
    }
}
