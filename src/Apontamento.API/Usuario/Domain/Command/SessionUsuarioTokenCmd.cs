using Apontamento.App.Usuario.Domain.Query;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Apontamento.App.Usuario.Domain.Command
{
    public class SessionUsuarioTokenCmd : IRequest<UsuarioQuery>
    {
        public string Email { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }
    }
}
