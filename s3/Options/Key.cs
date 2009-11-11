using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class AccessKey : OptionWithParameter<string>
    {

        public AccessKey() {
        }

        protected override bool parameterIsCompulsory {
            get { return true; }
        }

    }

    class SecretKey : OptionWithParameter<string> {

        public SecretKey() {
        }

        protected override bool parameterIsCompulsory {
            get { return true; }
        }

    }
    

}
