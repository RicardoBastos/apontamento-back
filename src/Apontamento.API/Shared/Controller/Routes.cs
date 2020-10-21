namespace Apontamento.App.Shared.Controller
{
    public static class Routes
    {
        public static class Empresa
        {
            public const string BuscarEmpresasPaginada = "listar";
            public const string SalvarEmpresa = "salvar";
            public const string AtualizarEmpresa = "atualizar/{id}";
            public const string BuscarEmpresaPorId = "buscar/{id}";

        }

        public static class Projeto
        {
            public const string BuscarProjetosPaginada = "listar";
            public const string SalvarProjeto = "salvar";
            public const string AtualizarProjeto = "atualizar/{id}";
            public const string BuscarProjetoPorId = "buscar/{id}";

        }

        public static class Usuario
        {
            public const string Autenticar = "autenticar";

        }
    }
}
