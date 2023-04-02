using FlightBookingSystemFolder.Models;
namespace FlightBookingSystemFolder.Repository;
public interface ITokenHandler
{
    string CreateTokenAsync(Registration reg);
}