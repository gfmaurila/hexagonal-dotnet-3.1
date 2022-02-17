using Domain.Dto;
using Domain.Dto.Usuario;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService clubService) => _userService = clubService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.All();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = new RetornoApiDto();
            result = await _userService.GetById(id);
            var code = result.Sucesso ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            result.StatusCode = (int)code;
            Response.StatusCode = (int)code;
            return Ok(result);
        }

        // PPOST api/values
        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] TodosCamposUsuarioDto UserDTO)
        {
            var result = new RetornoApiDto();
            result = await _userService.Adicionar(UserDTO);
            var code = result.Sucesso ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            result.StatusCode = (int)code;
            Response.StatusCode = (int)code;
            return Ok(result);
        }

        // PUT api/values
        [HttpPut]
        [Route("alterar")]
        public async Task<IActionResult> Alterar([FromBody] TodosCamposUsuarioDto UserDTO)
        {
            var result = new RetornoApiDto();
            result = await _userService.Update(UserDTO);
            var code = result.Sucesso ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            result.StatusCode = (int)code;
            Response.StatusCode = (int)code;
            return Ok(result);
        }

        // DELETE api/values
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BaseDto UserDTO)
        {
            var result = new RetornoApiDto();
            result = await _userService.Remove(UserDTO);
            var code = result.Sucesso ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            result.StatusCode = (int)code;
            Response.StatusCode = (int)code;
            return Ok(result);
        }
    }
}
