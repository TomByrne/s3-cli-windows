using System;
using System.Collections.Generic;
using System.Text;

namespace s3
{
    class SyntaxException : Exception
    {
        public SyntaxException(string message) : base(message) {}
    }
}
