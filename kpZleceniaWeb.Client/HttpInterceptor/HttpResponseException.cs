namespace kpZleceniaWeb.Client.HttpInterceptor
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException()
        {

        }

        public HttpResponseException(string message) : base(message)
        {

        }
    }
}
