using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Apontamento.App.Shared.Controller
{
    public class ValidationExceptionApi : Exception
    {
        public ValidationExceptionApi() : base("Erros de validação")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public ValidationExceptionApi(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }

}
