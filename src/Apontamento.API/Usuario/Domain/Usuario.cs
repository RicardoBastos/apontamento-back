using Apontamento.App.Shared.Domain;
using System;

namespace Apontamento.App.Usuario.Domain
{
    public class Usuario : Base
    {
        public Usuario()
        {
            Id = Guid.NewGuid();
        }

        public void SetUsuario(Guid id, string nome, string email, string senha, bool ativo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Ativo = ativo;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public bool Ativo { get; set; }
    }
}
