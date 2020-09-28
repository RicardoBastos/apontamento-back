using Apontamento.App.Shared.Domain;
using MediatR;
using System;

namespace Apontamento.App.Empresa.Domain.Command
{
    public partial class EmpresaCommand : IRequest<Response<Unit>>
    {
        public Guid Id { get; protected set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
