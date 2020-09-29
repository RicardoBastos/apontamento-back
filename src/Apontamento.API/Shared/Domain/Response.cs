using FluentValidation.Results;
using System.Collections.Generic;

namespace Apontamento.App.Shared.Domain
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(IEnumerable<ValidationFailure> failures)
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }
    }
}
