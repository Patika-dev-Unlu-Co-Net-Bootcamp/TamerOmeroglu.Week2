using HotelFinder.Entity;

namespace HotelFinder.API.UserValidation
{
    public class PasswordMinimumCharacterValidation : IValidation
    {
        private const int minimumCharacter = 10;

        public bool IsValid(User user)
        {
            if (user == null) return false;

            var check = user.Password.Length >= 10;

            return check;

        }
    }
}
