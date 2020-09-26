using Apontamento.App.Usuario.Validation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Apontamento.App.Usuario.Domain.Command
{
    public class UsuarioCmd : IRequest<ValidationResult>
    {
        public Guid Id { get; protected set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public void SetId(Guid id)
        {
            this.Id = id;
        }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        public virtual bool IsValid()
        {

            var validation = new UsuarioValidation();
            validation.ValidarNome();

            ValidationResult = validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
