using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Backup : Option
    {
        Backup()
        {
            if (ExecutionEnvironment.IsLinux)
                throw new SyntaxException("The /backup option is not available on Linux");
        }
    }
}
