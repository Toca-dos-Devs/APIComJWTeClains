using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using APIComJWTeClains.Models;
using APIComJWTeClains.Repositories;
using APIComJWTeClains.Services;

namespace APIComJWTeClains.Controllers
{
    [Route("v1/conta")]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user,
                token
            };
        }

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonymous() => "lucas";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("funcionario")]
        [Authorize(Roles = "funcionario,gerente")]
        public string Employee() => "Funcionário ricardo";

        [HttpGet]
        [Route("gerente")]
        [Authorize(Roles = "gerente")]
        public string Manager() => "Gerente";

    }
}
