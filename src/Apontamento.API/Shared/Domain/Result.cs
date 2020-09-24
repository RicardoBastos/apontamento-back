using System.Collections.Generic;

namespace Apontamento.App.Shared.Domain
{
    public class Result
    {
        public Result()
        {
            Errors = new List<string>();
        }

        public string Mensagem { get; set; }
        public List<string> Errors { get; set; }

        public bool hasErrors => Errors.Count > 0;

        public void AddError(string error) =>
            Errors.Add(error);

    }
}
