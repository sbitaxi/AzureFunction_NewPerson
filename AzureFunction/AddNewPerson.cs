using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace People.NewPerson
{
    public static class AddNewPerson
    {
        [FunctionName("AddNewPerson")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Receive query input in Function request
            string name = req.Query["name"];

            // Read the request body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            // Attempt to deserialize the request body into a Person object
            Person person = JsonConvert.DeserializeObject<Person>(requestBody);

            // Name is either the value passed in the Function request or 
            // the full name of the Person in the requestBody
            name = name ?? person?.CompleteRecord;

            // Return an OK message including the value stored in the name variable
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
