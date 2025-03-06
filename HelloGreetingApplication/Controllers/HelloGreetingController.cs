using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;

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
        public HelloGreetingController(ILogger<HelloGreetingController> logger , IGreetingBL greetingBL )
        {
            _logger = logger;
            _greetingBL = greetingBL; 
        }
        /// <summary>
        /// Delete Method to delete data from data base(UC8)
        /// </summary>
        /// <param name="id"></param>
        /// <returns> delete the element </returns>
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteGreeting(int id)
        {
            bool isDeleted = _greetingBL.DeleteGreeting(id);
            if (!isDeleted)
            {
                return NotFound($"Greeting with ID {id} not found.");
            }
            return Ok($"Greeting with ID {id} has been deleted.");
        }
        // 6?? Edit an existing greeting message(UC7)
        [HttpPut("update/{id}")]
        public ActionResult<GreetingEntity> UpdateGreeting(int id, [FromBody] string newMessage)
        {
            var updatedGreeting = _greetingBL.UpdateGreeting(id, newMessage);
            if (updatedGreeting == null)
            {
                return NotFound($"Greeting with ID {id} not found.");
            }
            return Ok(updatedGreeting);
        }
        /// <summary>
        /// get method to return list of all saved msgs(UC6)
        /// </summary>
        /// <returns>list of all saved </returns>
        [HttpGet("list")]
        public IActionResult GetAllGreetings()
        {
            var greetings = _greetingBL.GetAllGreetings();
            if (greetings == null || greetings.Count == 0)
            {
                return NotFound("No greetings found.");
            }
            return Ok(greetings);
        }
        /// <summary>
        /// Get method to give data according to the Id(UC5)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>gives data from the databse according to the Id</returns>
        [HttpGet("{id}")]
        public IActionResult GetGreetingById(int id)
        {
            var greeting = _greetingBL.GetGreetingById(id);
            if (greeting == null)
            {
                return NotFound("Greeting not found");
            }
            return Ok(greeting);
        }

        /// <summary>
        /// Get method to greet with names(UC3)
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>hello world with name</returns>
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
        /// <summary>
        /// Get Method to print Just Hello World!(UC2)
        /// </summary>
        /// <returns>Hello World</returns>
        
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Greeting2")]

        public IActionResult Greeting()
        {
            _logger.LogInformation("Fetching data from API");
            return Ok(new { Message = "Hello, World!" });
        }
        /// <summary>
        /// Get method to get the Greeting Message]
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
        /// Post method to save data to the database(UC4)
        /// </summary>
        /// <param name="message"></param>
        /// <returns>reflects the data that was entered in database in form of rows and columns</returns>
        [HttpPost("save")]
        public IActionResult SaveGreeting([FromBody] string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return BadRequest("Message cannot be empty!");

            var savedGreeting = _greetingBL.SaveGreeting(message);
            return Ok(savedGreeting);
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
