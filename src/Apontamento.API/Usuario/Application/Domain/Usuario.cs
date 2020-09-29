using Apontamento.App.Shared.Domain;
using System;

namespace Apontamento.App.Usuario.Application.Domain
{
    public class Usuario : Base
    {
        public Usuario()
        {
        }


        public void SetUsuario(Guid id, string nome, string email, string senha, bool status)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Status = status;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}
