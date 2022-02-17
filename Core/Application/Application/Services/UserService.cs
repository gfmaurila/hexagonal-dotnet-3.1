using Application.Convert;
using Domain.Adapters;
using Domain.Dto;
using Domain.Dto.Usuario;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        #region properties
        private readonly IUserRepository _repository;
        List<ListaUsuarioDto> userDTOs = new List<ListaUsuarioDto>();
        #endregion

        public UserService(IUserRepository repository) => (_repository) = (repository);

        public async Task<IEnumerable<ListaUsuarioDto>> All()
        {
            return ConvertUsuario.Lista(await _repository.GetAll());
        }

        public async Task<RetornoApiDto<TodosCamposUsuarioDto>> GetById(int id)
        {
            var result = new RetornoApiDto<TodosCamposUsuarioDto>();
            try
            {
                result.Retorno = ConvertUsuario.Find(await _repository.GetById(id));
                result.TotalRegistros = 1;
                result.Sucesso = true;
                result.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                result.Sucesso = false;
                //result.Mensagem = ex.Message;
                result.Mensagem = "Erro";
            }
            return result;

        }

        public async Task<TodosCamposUsuarioDto> GetByNameEmail(TodosCamposUsuarioDto dto)
        {
            return ConvertUsuario.Find(await _repository.FirstOrDefault(f => f.Email == dto.Email && 
                                                        f.Name == dto.Name && f.Gender == dto.Gender));
        }

        public async Task<RetornoApiDto<TodosCamposUsuarioDto>> Adicionar(TodosCamposUsuarioDto dto)
        {
            var result = new RetornoApiDto<TodosCamposUsuarioDto>();
            try
            {
                dto.Validate();
                await _repository.Add(ConvertUsuario.AddEUpdate(dto));
                result.Retorno = await GetByNameEmail(ConvertUsuario.GetByNameEmail(dto));
                result.TotalRegistros = 1;
                result.Sucesso = true;
                result.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                result.Sucesso = false;
                //result.Mensagem = ex.Message;
                result.Mensagem = "Erro";
            }
            return result;
        }

        public async Task<RetornoApiDto<TodosCamposUsuarioDto>> Update(TodosCamposUsuarioDto dto)
        {
            var result = new RetornoApiDto<TodosCamposUsuarioDto>();
            try
            {
                dto.Validate();
                await _repository.Update(ConvertUsuario.AddEUpdate(dto));
                result.Retorno = await GetByNameEmail(ConvertUsuario.GetByNameEmail(dto));
                result.TotalRegistros = 1;
                result.Sucesso = true;
                result.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                result.Sucesso = false;
                //result.Mensagem = ex.Message;
                result.Mensagem = "Erro";
            }
            return result;
        }

        public async Task<RetornoApiDto> Remove(BaseDto dto)
        {
            var result = new RetornoApiDto();
            try
            {
                await _repository.Remove(ConvertUsuario.Remover(dto));
                result.Sucesso = true;
                result.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                result.Sucesso = false;
                //result.Mensagem = ex.Message;
                result.Mensagem = "Erro";
            }
            return result;
        }
    }
}
