using Apontamento.App.Shared.Domain;
using Apontamento.App.Usuario.Application.Domain.Query;
using MediatR;

namespace Apontamento.App.Usuario.Application.Domain.Command
{
    public partial class UsuarioCommand : IRequest<Response<UsuarioQuery>>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }



}
