using FluentValidation.Results;
using System.Collections.Generic;

namespace Apontamento.Shared.Domain
{
    public class Response<T>
    {
        public Response()
        {
            Errors = new List<string>();
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
        public Response<T> ResponseMessage(string message, bool succeeded = true)
        {
            Succeeded = succeeded;
            Message = message;
            return this;
        }



        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public int TotalRecords { get; set; }
        public T Data { get; set; }
    }
}
