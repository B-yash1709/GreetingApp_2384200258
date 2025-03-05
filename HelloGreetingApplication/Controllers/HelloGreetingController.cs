using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using BusinessLayer.Interface;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// Class Providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly IGreetingBL _greetingBL;
        private readonly ILogger<HelloGreetingController> _logger;
        public HelloGreetingController(ILogger<HelloGreetingController> logger , IGreetingBL greetingBL)
        {
            _logger = logger;
            _greetingBL = greetingBL;
        }
        [HttpGet("greeting3")]
        public IActionResult GetGreetingMessage(string? firstName, string? lastName)
        {
            UserModel userModel = new UserModel
            {
                FirstName = firstName ?? string.Empty,
                LastName = lastName ?? string.Empty
            };

            _logger.LogInformation($"Get request received with Firstname: {userModel.FirstName}, Lastname: {userModel.LastName}");

            string message = _greetingBL.GetGreetingMessage(userModel); // Pass UserModel instead of separate params

            ResponseModel<string> responseModel = new ResponseModel<string>()
            {
                Success = true,
                Message = "Greet Message generated Successfully",
                Data = message
            };

            return Ok(responseModel);
        }

        
        [HttpGet]
        [Route("greeting1")]
        public IActionResult GetMessage()
        {
            var message = _greetingBL.PrintHelloWorld();
            ResponseModel<string> responseModel = new()
            {
                Success = true,
                Message = "Hello endpoint hit API",
                Data = message
            };
            return Ok(responseModel);
        }
        [HttpGet]
        [Route("Greeting2")]

        public IActionResult Greeting()
        {
            _logger.LogInformation("Fetching data from API");
            return Ok(new { Message = "Hello, World!" });
        }
        /// <summary>
        /// Get method to get the Greeting Message
        /// </summary>
        /// <returns>"Hello World!"</returns>
        [HttpGet("greeting4")]

        public IActionResult Get()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();

            responseModel.Success = true;
            responseModel.Message = "Hello endpoint hit API";
            responseModel.Data = "Hello World!";
            return Ok(responseModel);
        }
        /// <summary>
        /// Post method to Add new object
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>Added Value </returns>
        [HttpPost]
        public IActionResult Post(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request recieved successfully";
            responseModel.Data = $"UserId: {requestModel.UserId}, key: {requestModel.key}, Value: {requestModel.value}";
            return Ok(responseModel);
        }
        /// <summary>
        /// Put method to update(fully) in existing object
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>Updated value</returns>
        [HttpPut]
        public IActionResult Put(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request recieved for full updation.";
            responseModel.Data = $"UserId: {requestModel.UserId},key: {requestModel.key}, Value: {requestModel.value}";
            return Ok(requestModel);
        }
        /// <summary>
        /// Patch method to update(Partially) in existing objecct
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult Patch(RequestModel requestModel)
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request recieved for partial updation.";
            responseModel.Data = $"UserId: {requestModel.UserId},key: {requestModel.key}, Value: {requestModel.value}";
            return Ok(requestModel);
        }
        /// <summary>
        /// Delete method to Delete existing value
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>null</returns>
        [HttpDelete]
        public IActionResult Delete()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>();
            responseModel.Success = true;
            responseModel.Message = "Request recieved for deletion ";
            responseModel.Data = string.Empty;
            return Ok(responseModel);
        }
    }
}
