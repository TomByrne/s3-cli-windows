using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Big : OptionWithParameter<double>
    {
        protected override bool parameterIsCompulsory
        {
            get { return false; }
        }
    }
}
