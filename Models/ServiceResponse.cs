namespace LaBestiaNet.Models
{
    public class ServiceResponse<T>
    {
        public ServiceResponse(bool ok, T? data, string message)
        {
            this.ok = ok;
            this.data = data;
            this.message = message;
        }

        public bool ok { get; set; }
        public T? data { get; set; }
        public string message { get; set; } = string.Empty;
    }
}
