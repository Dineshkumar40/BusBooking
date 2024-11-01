
namespace BusBooking.Models.Models
{
    public class ServiceResponseData<T>: ServiceResponse
    {
        public T Data { get; set; }
    }
}
