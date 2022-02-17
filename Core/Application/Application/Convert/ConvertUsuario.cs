using Domain.Dto;
using Domain.Dto.Usuario;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Convert
{
    public static class ConvertUsuario
    {
        public static IEnumerable<ListaUsuarioDto> Lista(IEnumerable<User> lista)
        {
            List<ListaUsuarioDto> userDTOs = new List<ListaUsuarioDto>();

            if (lista == null)
                return null;

            foreach (var item in lista)
            {
                ListaUsuarioDto dto = new ListaUsuarioDto
                {
                    Name = item.Name,
                    Email = item.Email,
                    Gender = item.Gender
                };
                userDTOs.Add(dto);
            }
            return userDTOs;
        }

        public static TodosCamposUsuarioDto Find(User find)
        {
            if (find == null)
                return null;

            TodosCamposUsuarioDto dto = new TodosCamposUsuarioDto
            {
                Id = find.Id,
                Name = find.Name,
                Email = find.Email,
                Gender = find.Gender
            };
            return dto;
        }

        public static TodosCamposUsuarioDto GetByNameEmail(TodosCamposUsuarioDto find)
        {
            if (find == null)
                return null;

            TodosCamposUsuarioDto dto = new TodosCamposUsuarioDto
            {
                Name = find.Name,
                Email = find.Email,
                Gender = find.Gender
            };
            return dto;
        }

        public static User AddEUpdate(TodosCamposUsuarioDto dto)
        {
            dto.Validate();

            User obj = new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Gender = dto.Gender
            };
            return obj;
        }

        public static User Editar(TodosCamposUsuarioDto dto)
        {
            dto.Validate();

            User obj = new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Gender = dto.Gender
            };
            return obj;
        }

        public static User Remover(BaseDto dto)
        {
            User obj = new User
            {
                Id = dto.Id,
            };
            return obj;
        }
    }
}
