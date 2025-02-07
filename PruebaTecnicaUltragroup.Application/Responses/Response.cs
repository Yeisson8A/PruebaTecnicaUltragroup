using FluentValidation.Results;

namespace PruebaTecnicaUltragroup.Application.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
