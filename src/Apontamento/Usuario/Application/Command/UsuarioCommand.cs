using Apontamento.Shared.Domain;
using Apontamento.Usuario.Application.Query;
using MediatR;

namespace Apontamento.Usuario.Application.Command
{
    public partial class UsuarioCommand : IRequest<Response<UsuarioQuery>>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }



}
