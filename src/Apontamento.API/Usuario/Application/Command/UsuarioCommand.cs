using Apontamento.App.Shared.Domain;
using Apontamento.App.Usuario.Application.Query;
using MediatR;

namespace Apontamento.App.Usuario.Application.Command
{
    public partial class UsuarioCommand : IRequest<Response<UsuarioQuery>>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }



}
