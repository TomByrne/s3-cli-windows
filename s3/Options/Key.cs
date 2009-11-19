using System;
using System.Collections.Generic;
using System.Text;

using com.amazon.s3;

namespace s3.Options
{
    class Key : OptionWithParameter<string>
    {
        internal static bool overridden = false;

        public Key() { }

        protected override bool ParameterIsCompulsory
        {
            get { return true; }
        }

        protected override void ParameterIsSet()
        {
            AWSAuthConnection.OUR_ACCESS_KEY_ID = Parameter;
            overridden = true;
        }

        public static bool KeyOverridden
        {
            get { return Key.overridden && Secret.overridden; }
        }
    }

    class Secret : OptionWithParameter<string>
    {
        internal static bool overridden = false;

        public Secret() { }

        protected override bool ParameterIsCompulsory
        {
            get { return true; }
        }

        protected override void ParameterIsSet()
        {
            AWSAuthConnection.OUR_SECRET_ACCESS_KEY = Parameter;
            overridden = true;
        }
    }
}
