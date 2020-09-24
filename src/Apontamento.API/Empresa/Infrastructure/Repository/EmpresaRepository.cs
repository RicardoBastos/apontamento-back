using Apontamento.App.Empresa.Infrastructure.Repository.Interfaces;
using Apontamento.App.Shared.Infra;

namespace Apontamento.App.Empresa.Repository
{
    public class EmpresaRepository : RepositoryBase<Domain.Empresa>, IEmpresaRepository
    {
        private readonly ApontamentoContext _context;
        public EmpresaRepository(ApontamentoContext context):base(context)
        {
            _context = context;
        }

        public ApontamentoContext Context { get; }

        //public RetornoGrid<EmpresaQuery> BuscarEmpresasPaginada()
        //{
        //    var retorno = new RetornoGrid<EmpresaQuery>();
        //    var query = _context.Empresa.Where(p => p.Status == true);

        //    var results = query.OrderBy(p => p.Nome)
        //           .Select(p => new
        //           {
        //               EmpresaQuery = new EmpresaQuery { Id = p.Id, Nome = p.Nome, Status = p.Status },
        //               TotalCount = query.Count()
        //           })
        //           .Skip(0).Take(5)
        //           .ToArray();

        //    retorno.TotalRecords = results.First().TotalCount;
        //    retorno.Data = results.Select(r => r.EmpresaQuery).ToList();

        //    return retorno;
        //}
    }
}
