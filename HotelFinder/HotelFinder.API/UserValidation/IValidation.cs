using HotelFinder.Entity;

namespace HotelFinder.API.UserValidation
{
    public interface IValidation
    {
        public bool IsValid(User user);
    }
}
