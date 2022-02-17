using Domain.Dto;
using Domain.Dto.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<ListaUsuarioDto>> All();
        Task<RetornoApiDto<TodosCamposUsuarioDto>> GetById(int id);
        Task<TodosCamposUsuarioDto> GetByNameEmail(TodosCamposUsuarioDto dto);
        Task<RetornoApiDto<TodosCamposUsuarioDto>> Adicionar(TodosCamposUsuarioDto dto);
        Task<RetornoApiDto<TodosCamposUsuarioDto>> Update(TodosCamposUsuarioDto dto);
        Task<RetornoApiDto> Remove(BaseDto dto);
    }
}
