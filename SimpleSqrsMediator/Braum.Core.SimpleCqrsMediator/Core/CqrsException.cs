using System;

namespace Braum.Core.SimpleCqrsMediator.Core
{
    public class CqrsException : Exception
    {
        public CqrsException(string message)
        : base(message)
        {
        }
    }
}
