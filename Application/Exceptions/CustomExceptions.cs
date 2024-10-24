using System;
using System.Collections.Generic;

namespace CustomExceptions
{
    public class ProductNotFoundException : Exception
    {
        public List<long> MissingProductIds { get; }
        
        public ProductNotFoundException(string message)
            : base(message)
        {
        }
        
    }
}