using MemoProject.model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace MemoProject.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;
        public UserController(UserManager userManager) 
        { 
            _userManager = userManager;
        }

      

        [HttpGet]
        [Route("GetList/page={page}/per_page={per_page}")]
        public async Task<IActionResult> GetList(int page, int per_page)
        {
            string apiResponse = await _userManager.getList(page, per_page);
            return  Ok(apiResponse);
        }
        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            string apiResponse = await _userManager.getUser(id);
            return Ok(apiResponse);
        }
        [HttpPost]
        [Route("CreateUser")]

        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            
            string apiResponse = await _userManager.CreateUser(user);
            return Ok(apiResponse);
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]

        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var userCheck = _userManager.getUser(id);
            if (userCheck is {})
            {
                return StatusCode(500);
            }
            else
            {

            string apiResponse = await _userManager.UpdateUser(id, user);
            return Ok(apiResponse);
            }
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]

        public async Task<HttpStatusCode> DeleteUser(int id)
        {
                var apiResponse = await _userManager.DeleteUser(id);
                return apiResponse;
          
        }

    }
}
