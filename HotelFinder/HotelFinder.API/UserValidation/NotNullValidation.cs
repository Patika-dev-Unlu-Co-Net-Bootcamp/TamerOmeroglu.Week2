using HotelFinder.Entity;
using System.Linq;

namespace HotelFinder.API.UserValidation
{
    public class NotNullValidation : IValidation
    {
        public bool IsValid(User user)
        {
            bool isNull = user.GetType().GetProperties()
                            .All(p => p.GetValue(user) != null);

            return isNull;
        }
       
        
    }
}
