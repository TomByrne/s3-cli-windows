using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Key : OptionWithParameter<string>
    {

        public Key() {
        }

        protected override bool ParameterIsCompulsory {
            get { return true; }
        }

    }

    class Secret : OptionWithParameter<string> {

        public Secret() {
        }

        protected override bool ParameterIsCompulsory {
            get { return true; }
        }

    }
    

}
