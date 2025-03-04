using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// Class Providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingController : ControllerBase
    {
        private readonly ILogger<HelloGreetingController> _logger;
        public HelloGreetingController(ILogger<HelloGreetingController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Greeting")]

        public IActionResult Greeting()
        {
            _logger.LogInformation("Fetching data from API");
            return Ok(new { Message = "Hello, World!" });
        }
        /// <summary>
        /// Get method to get the Greeting Message
        /// </summary>
        /// <returns>"Hello World!"</returns>
        [HttpGet]

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
