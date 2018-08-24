using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SSupply.Products.Exceptions
{
    [Serializable]
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(Guid id)
            : base($"A product with the Id {id} could not be found.") { }

        protected ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
