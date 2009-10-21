using System;
using System.Collections.Generic;
using System.Text;

namespace s3
{
    class SyntaxError : Exception
    {
        public string why;

        public SyntaxError(string why)
        {
            this.why = why;
        }
    }

    class NotFoundException : Exception
    {
        public string what;

        public NotFoundException(string what)
        {
            this.what = what;
        }
    }
}
