using System;

namespace HotelFinder.API.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }

        public BadRequestException()
        {

        }
    }
}
