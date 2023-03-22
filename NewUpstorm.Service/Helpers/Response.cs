namespace NewUpstorm.Service.Helpers
{
    public class Response<TResult>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public TResult Value { get; set; }
    }
}
