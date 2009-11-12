using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Acl : OptionWithParameter<string>
    {
        protected override bool ParameterIsCompulsory
        {
            get { return true; }
        }
    }
}
