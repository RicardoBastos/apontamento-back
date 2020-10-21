using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Apontamento.App.Shared.Controller;
using Apontamento.App.Shared.Interfaces.Repository;
using Apontamento.App.Shared.Domain;
using Apontamento.App.Usuario.Infrastructure.Repository.Interfaces;
using Apontamento.App.Usuario.Application.Command;
using Apontamento.App.Usuario.Application.Query;
using Microsoft.Extensions.Options;

namespace Apontamento.App.Usuario.Application.Handler
{
    public class UsuarioHandler :
        CommandHandler,
    IRequestHandler<AutenticarCommand, Response<UsuarioQuery>>
    {
        private readonly IUsuarioDapperRepository _usuarioDapperRepository;
        private readonly AppSettings _appSettings;

        public UsuarioHandler(IUsuarioDapperRepository usuarioDapperRepository, IOptions<AppSettings> appSettings, IUnitOfWork uow) : base(uow)
        {
            _usuarioDapperRepository = usuarioDapperRepository;
            _appSettings = appSettings.Value;
        }


        public async Task<Response<UsuarioQuery>> Handle(AutenticarCommand request, CancellationToken cancellationToken)
        {
            var qUsuario = await _usuarioDapperRepository.BuscarUsuarioPorEmail(request.Email);
            qUsuario.Token = generateJwtToken(qUsuario.Id);

            return await Task.FromResult(new Response<UsuarioQuery>(qUsuario));
        }

        private string generateJwtToken(Guid id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
