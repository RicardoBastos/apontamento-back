using Apontamento.App.Shared.Domain;
using MediatR;
using System;

namespace Apontamento.App.Projeto.Application.Command
{
    public partial class ProjetoCommand : IRequest<Response<Unit>>
    {
        public Guid Id { get; protected set; }
        public string Nome { get; set; }
        public int Horas{ get; set; }
        public Guid EmpresaId { get; set; }
    }
}
