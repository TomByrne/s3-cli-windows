using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Days : OptionWithParameter<int>
    {
        internal int days;

        protected override bool ParameterIsCompulsory
        {
            get { return true; }
        }

        protected override void ParameterIsSet()
        {
            if (Parameter < 0)
                throw new SyntaxException("The paramter to the /days option must be zero or greater");

            days = Parameter;
        }
    }
}
