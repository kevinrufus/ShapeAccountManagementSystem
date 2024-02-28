using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShapeAccountManagementSystem.Core.Dtos.Receivables;
using ShapeAccountManagementSystem.Core.Interfaces;
using ShapeAccountManagementSystem.Models;
using ShapeAccountManagementSystem.Models.Receivables;
using System.Net;

namespace ShapeAccountManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper,IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("signup", Name = "Signup")]
        public async Task<ActionResult<ResponseModel>> Signup(UserReceivableDto input)
        {
            bool result = await _userService.CreateUser(_mapper.Map<CreateUserReceivableDto>(input));
            if (result) return Ok(new ResponseModel(result, (int)HttpStatusCode.OK, true, "User registered successfuly"));
            else return BadRequest(new ResponseModel
                (result, (int)HttpStatusCode.BadRequest, false, "Email is already registered"));
        }

        [HttpPost("login", Name ="Login")]
        public async Task<ActionResult<ResponseModel>> Login(LoginReceivableDto login)
        {
            bool result = await _userService.Login(login.UserName, login.Password);
            if (result) return Ok(new ResponseModel(result, (int)HttpStatusCode.OK, true, "Login successful"));
            else return Unauthorized(new ResponseModel
                (result, (int)HttpStatusCode.BadRequest, false, "Invalid credentials"));
        }
    }
}
