using System.Runtime.Serialization;

namespace Shared.Exceptions
{
    [Serializable]
    public class BoundaryException : Exception
    {
        public BoundaryException(string message = "The worm is out of 30 by 30 section") : base(message) { }
        protected BoundaryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
