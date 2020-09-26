using Apontamento.App.Usuario.Infrastructure.Repository;
using Apontamento.App.Usuario.Validation;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Apontamento.App.Usuario.Domain.Command
{

    public class SessionUsuarioCmd : IRequest<ValidationResult>
    {
        public SessionUsuarioCmd() { }

        public SessionUsuarioCmd(string email, string senha)
        {
            this.Email = email;
            this.Senha = senha;

        }

        public string Email { get; set; }

        public string Senha { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid(IUsuarioDapperRepository usuarioDapperRepository)
        {
            var validation = new SessionValidation(usuarioDapperRepository);

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
