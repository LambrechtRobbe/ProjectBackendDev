using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WickedQuiz.API.ApiModels;
using WickedQuiz.Models.Models;

namespace WickedQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInMgr;

        public AuthController(SignInManager<ApplicationUser> signInMgr)
        {
            _signInMgr = signInMgr;
        }

        // GET: api/Auth
        [AllowAnonymous]
        [HttpPost] [Route("login")] //vult de controller basis route aan [AllowAnonymous] 
        public async Task<IActionResult> Login([FromBody] Login_DTO loginDTO ) 
        { //LoginViewModel met (Required) UserName en Password aanbrengen. 
            var returnMessage = ""; 
            if (!ModelState.IsValid) 
                return BadRequest("Onvolledige gegevens."); 
            try 
            { //geen persistence, geen lockout -> via false, false 
                var result = await _signInMgr.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false); 
                if (result.Succeeded) 
                { 
                    return Ok("Welkom " + loginDTO.UserName); 
                } 
                throw new Exception("User of paswoord niet gevonden."); //zo algemeen mogelijk response. Vertelt niet dat het pwd niet juist is. 
            } 
            catch (Exception ex) 
            { 
                returnMessage = $"Foutief of ongeldig request: {ex.Message}"; ModelState.AddModelError("", returnMessage); 
            } 
            return BadRequest(returnMessage); //zo weinig mogelijk (hacker) info 
        }
    }
}
