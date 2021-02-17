using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using Login.Application.ViewModels;
using Login.Application.Interfaces;
using Login.Domain.Models;
using Login.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Login.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : WebApiControllerBase
    {

        public string login
        {
            get
            {
                return ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Sid).Value;
            }
        }
      
        [HttpPut("Signin")]
        [AllowAnonymous]
        public IActionResult Signin(string email, string password)
        {            
            try
            {
                var service = Provider.GetService<IUserApplication>();
                var data = service.Signin(email, password);

                return Ok(data);
            }
            catch (ArgumentException ex)
            {
                vmError erro = new vmError();
                erro.errorCode = Convert.ToInt32(ex.ParamName);
                erro.message = ex.Message;
                return BadRequest(erro);
            }
        }
        [HttpPost("SignUp")]
        [AllowAnonymous]
        public IActionResult SignUp(vmUser user)
        {            
            try
            {
                var service = Provider.GetService<IUserApplication>();
                service.SignUp(user);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                vmError erro = new vmError();
                erro.errorCode = Convert.ToInt32(ex.ParamName);
                erro.message = ex.Message;
                return BadRequest(erro);
            }
        }

        [HttpGet("Me")]
        public IActionResult Me()
        {
            vmUser ret = new vmUser();
            try
            {
                var service = Provider.GetService<IUserApplication>();

                ret = service.Me(login);

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
