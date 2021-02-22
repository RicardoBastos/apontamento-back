using MediatR;
using System;

namespace Apontamento.Empresa.Domain.Notifications
{
    public class EmpresaSalvarNotification : INotification
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
