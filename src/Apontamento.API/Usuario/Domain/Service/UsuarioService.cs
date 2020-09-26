using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Apontamento.App.Usuario.Domain.Command;
using Apontamento.App.Usuario.Domain.Query;
using Apontamento.App.Usuario.Infrastructure.Repository;
using Apontamento.App.Shared.Controller;
using FluentValidation.Results;
using NetDevPack.Messaging;

namespace Apontamento.App.Usuario.Domain.Service
{
    public class UsuarioService : CommandHandler, 
        IRequestHandler<SessionUsuarioCmd, ValidationResult>, 
        IRequestHandler<SessionUsuarioTokenCmd, UsuarioQuery>
    {
        private readonly IUsuarioDapperRepository _usuarioDapperRepository;
        private readonly AppSettings _appSettings;



        public UsuarioService(IUsuarioDapperRepository usuarioDapperRepository, IOptions<AppSettings> appSettings)
        {
            this._usuarioDapperRepository = usuarioDapperRepository;
            this._appSettings = appSettings.Value;
        }


        public async Task<ValidationResult> Handle(SessionUsuarioCmd request, CancellationToken cancellationToken)
        {
            if (!request.IsValid(_usuarioDapperRepository)) return request.ValidationResult;

            return ValidationResult;
        }



        public async Task<UsuarioQuery> Handle(SessionUsuarioTokenCmd request, CancellationToken cancellationToken)
        {
            var qUsuario = await _usuarioDapperRepository.BuscarUsuarioPorEmail(request.Email);
            qUsuario.Token = generateJwtToken(qUsuario.Id);

            return qUsuario;
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
