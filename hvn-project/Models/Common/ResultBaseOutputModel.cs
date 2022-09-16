using System.Net;

namespace hvn_project.Models.Common
{
    public class ResultBaseOutputModel<T>
    {
        public T Result { get; set; }
        public string Error { get; set; }
        public HttpStatusCode Success
        {
            get => string.IsNullOrEmpty(Error) ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        }

        public void AddResultOk(T result)
        {
            Result = result;
        }

        public void AddError(string error)
        {
            Error = error;
        }
    }
}
