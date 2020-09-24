using System.Collections.Generic;

namespace Apontamento.App.Shared.Controller
{
    public class RetornoGrid<T> where T : class
    {
        public List<T> Data { get; set; }
        public int TotalRecords { get; set; }

    }

}
