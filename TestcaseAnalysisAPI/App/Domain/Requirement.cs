﻿using ExcelDataReader;

namespace TestCaseAnalysisAPI.App
{
    public class Requirement
    {
        public Requirement(IExcelDataReader reader)
        {

            var id = reader.GetValue(1);
            if (!string.IsNullOrWhiteSpace(id?.ToString()))
            {
                this.ID = reader.GetValue(1)?.ToString();
            }


            this.Objective = reader.GetString(5);

            this.changeStatus = reader.GetString(3);
            this.panaStatus = reader.GetString(10);
            this.VerificationMeasure = reader.GetValue(16)?.ToString().Replace("\n","");
            this.Type = reader.GetValue(8)?.ToString();
            //this.EpicIDs = reader
            //    .GetString(21)?
            //    .Split("\n", System.StringSplitOptions.RemoveEmptyEntries)
            //    ?? new string[0];

        }

        public string ID { get; }
        public string Objective { get; }
        public string changeStatus { get; }
        public string panaStatus { get; }
        public string VerificationMeasure { get; }
        public string Type { get; }
        public string[] EpicIDs { get; }


    }
}