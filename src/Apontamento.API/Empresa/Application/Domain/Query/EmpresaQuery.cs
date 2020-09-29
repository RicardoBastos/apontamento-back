using System;

namespace Apontamento.App.Empresa.Application.Domain.Query
{
    public class EmpresaQuery
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
