namespace Apontamento.App.Shared.Controller
{
    public static class Routes
    {
        public static class Empresa
        {
            public const string BuscarEmpresasPaginada = "listar";
            public const string SalvarEmpresa = "salver";
            public const string AtualizarEmpresa = "atualizar/{id}";

        }

        public static class Usuario
        {
            public const string Autenticar = "autenticar";

        }
    }
}
