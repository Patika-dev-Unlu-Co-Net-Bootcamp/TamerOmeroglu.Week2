using HotelFinder.API.Extensions;
using HotelFinder.Entity;

namespace HotelFinder.API.Services
{
    public class UserService
    {
        public bool UserIsValid(User user)
        {
            return user.IsValid();
        }

    }
}
