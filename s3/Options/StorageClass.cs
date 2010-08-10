using System;
using System.Collections.Generic;
using System.Text;

using com.amazon.s3;

namespace s3.Options
{
    class StorageClass : OptionWithParameter<string>
    {
        protected override bool ParameterIsCompulsory
        {
            get { return false; }
        }
    }
}
