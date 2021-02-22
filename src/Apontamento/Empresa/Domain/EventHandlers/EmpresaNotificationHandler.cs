using Apontamento.Empresa.Domain.Notifications;
using Apontamento.Projeto.Application.Command;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Apontamento.Empresa.Domain.EventHandlers
{
    public class EmpresaNotificationHandler :
        INotificationHandler<EmpresaSalvarNotification>
    {

        private readonly IMediator _mediator;


        public EmpresaNotificationHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Handle(EmpresaSalvarNotification notification, CancellationToken cancellationToken)
        {
            //Enviar para fila 
            return Task.Run(() =>
            {
                _mediator.Send(new ProjetoSalvarCommand() { Nome = notification.Nome, Horas = 22, EmpresaId = notification.Id });
            });
        }
    }
}
