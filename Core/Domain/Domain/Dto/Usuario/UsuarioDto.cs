using System;

namespace Domain.Dto.Usuario
{
    public class TodosCamposUsuarioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        #region Validations
        public void Validate()
        {
            ValidateName();
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Por favor, informe um nome.");

            if (Name.Length <= 3)
                throw new Exception("O nome deve ter pelo menos 3 caracteres.");

            if (Name.Length >= 100)
                throw new Exception("O nome não deve ter mais de 100 caracteres.");
        }
        #endregion
    }

    public class ListaUsuarioDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
