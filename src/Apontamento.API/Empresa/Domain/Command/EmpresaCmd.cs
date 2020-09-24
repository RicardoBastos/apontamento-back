using FluentValidation.Results;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Apontamento.App.Empresa.Domain.Command
{
    public class EmpresaCmd: IRequest<ValidationResult>
    {
        public Guid Id { get; protected set; }
        public string Nome { get; set; }
        public bool Status { get; set; }

        public void SetId(Guid id)
        {
            this.Id = id;
        }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

    }
}
