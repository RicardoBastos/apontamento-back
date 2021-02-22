namespace Apontamento.Shared.Controller
{
    public class Paginacao
    {
        public string OrderBy { get; set; }
        public string Direction { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
