using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Domain.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IValidatePassword _validatePassword;
        public PasswordController(IValidatePassword validatePassword)
        {
            _validatePassword = validatePassword;
        }
        [HttpGet]
        [Route("is-valid")]
        public async Task<ActionResult<bool>> IsValid()
        {
            var password = await new StreamReader(Request.Body, Encoding.UTF8).ReadToEndAsync();
            
            var isInputPasswordValid = _validatePassword.IsValid(password);
            return Ok(isInputPasswordValid);
        }
    }
}