using System;

namespace FinRust.Domain.Exceptions
{
    public class GenericException : Exception
    {
        public GenericException()
        {
            //Domain exception only used in domain logic, i.e. a function in an entity
        }
    }
}
