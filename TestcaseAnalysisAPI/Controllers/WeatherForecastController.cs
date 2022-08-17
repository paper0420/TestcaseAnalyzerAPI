using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCaseAnalysisAPI.App;


namespace TestcaseAnalysisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string file)
        {
            if (file == null)
            {
                return "No data";

            }

            return "XX";
        }

        public async Task<string> OnPostUploadAsync(IFormFile newFile, IFormFile currentFile,string type)
        {
            //if(newFile==null || currentFile == null)
            //{
            //    return "Please select both files";
            //}

            //var newFilePath = "Upload/newFile.xlsx";
            
            //using (var stream = System.IO.File.Create(newFilePath))
            //{
            //    await newFile.CopyToAsync(stream);
            //}

            //var currentFilePath = "Upload/currentFile.xlsx";
            //using (var stream = System.IO.File.Create(currentFilePath))
            //{
            //    await currentFile.CopyToAsync(stream);
            //}

            MyApp baseLineApp = new MyApp();


            //var output = baseLineApp.RunMyApp(newFilePath, currentFilePath,type);
            var output = baseLineApp.RunMyApp(null, null, type);

            if (output == null)
            {
                return "No output";
            }

            return output;

                       
        }

    }
}
