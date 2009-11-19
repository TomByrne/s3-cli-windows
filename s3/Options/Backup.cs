using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Backup : Option
    {
        protected override void Initialise(string parameter)
        {
            if (Utils.IsLinux)
                throw new SyntaxException("The /backup option is not available on Linux");

            base.Initialise(parameter);
        }
    }
}
