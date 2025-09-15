using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRicos.Application.Shared.Results
{
    public record Error(string Code, string Message)
    {
        public static Error None = new(string.Empty, string.Empty);
        public static Error NullValue = new("NULL_VALUE", "The value cannot be null.");
    }
}