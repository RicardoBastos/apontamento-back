using System;

namespace Apontamento.Empresa.Domain.Queries
{
    public class EmpresaQuery
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
