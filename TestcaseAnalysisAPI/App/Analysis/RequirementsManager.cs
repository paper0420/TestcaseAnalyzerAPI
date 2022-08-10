using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCaseAnalysisAPI.App
{
    public class RequirementsManager
    {
        public string NewRequirements  { get; set; }

        public void CompareBaseline(SpecParameters spec)
        {
            HashSet<string> oReq = new HashSet<string>();
            HashSet<string> nReq = new HashSet<string>();

            foreach (var oldReq in spec.currentRequirements)
            {
                oReq.Add(oldReq.ID);
            }

            foreach (var newReq in spec.newRequirements)
            {
                nReq.Add(newReq.ID);
            }

            this.NewRequirements = "New requirments = ";

            foreach (var aNewReq in nReq)
            {
                if (!oReq.Contains(aNewReq))
                {
                    this.NewRequirements += $"{aNewReq},";

                    //Console.WriteLine($"{aNewReq}");
                    continue;
                }
            }



        }



        public static void FindTestCasesLinked(SpecParameters spec)
        {
            foreach (var syr in spec.syrItems)
            {
                foreach (var req in syr.RequirementIDs)
                {
                    var detail = $"{req}";
                    var status = "";
                    var tcIDLinked = "";
                    var verificationMeasure = "";


                    var isDeleted = spec.delReqs.Any(t => t.ID == req);
                    if (isDeleted)
                    {
                        status = "Deleted";
                    }

                    if (!isDeleted)
                    {
                        var isRejected = spec.rejReqs.Any(t => t.ID == req);

                        if (isRejected)
                        {
                            status = "Rejected";
                        }
                    }

                    var isLinked = false;
                    foreach (var tc in spec.testCases)
                    {
                        var isTCLinked = tc.RequirementIDs.Any(t => t == req);
                        if (isTCLinked)
                        {
                            tcIDLinked += $"{tc.ID} ";
                            isLinked = true;
                        }

                    }

                    if (!isLinked)
                    {
                        tcIDLinked = "No";
                    }

                    foreach (var KLH in spec.currentRequirements)
                    {
                        if (req == KLH.ID)
                        {
                            verificationMeasure = KLH.VerificationMeasure;
                            break;
                        }
                    }

                    Console.WriteLine($"{syr.ID}|{syr.Objective}|{detail}|{status}|{tcIDLinked}|{syr.Allocation}|{verificationMeasure}|{syr.SYR_ID}");

                }
            }

        }

        public static void FindENG9TestCasesLinked(SpecParameters spec)
        {
            foreach (var syr in spec.syrLists)
            {
                var testCaseID = "";
                var isLinked = false;
                foreach (var tc in spec.eng9FuncTestCases)
                {
                    if(tc.SYR_ID != null)
                    {
                        if (syr.SYR_ID.Contains(tc.SYR_ID))
                        {
                            testCaseID += $"{tc.ID} ";
                            isLinked = true;
                            continue;
                            
                        }

                    }
             

                }

                if (!isLinked)
                {
                    testCaseID = "No";
                }

                Console.WriteLine($"{syr.SYR_ID}|{testCaseID}|");

            }
        }

    }


}

