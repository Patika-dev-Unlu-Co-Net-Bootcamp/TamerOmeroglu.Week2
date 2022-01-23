using HotelFinder.API.UserValidation;
using HotelFinder.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HotelFinder.API.Extensions
{
    public static class UserExtensions
    {
        public static bool IsValid(this User u)
        {
            var validationList = new List<IValidation>();

            validationList.Add(new NotNullValidation());
            validationList.Add(new PasswordMinimumCharacterValidation());

            return validationList.All(x => x.IsValid(u));
        }
    }
}
