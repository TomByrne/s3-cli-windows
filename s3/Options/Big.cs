using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Big : OptionWithParameter<double>
    {
        private const double defaultChunkMegabytes = 10;
        public double chunkMegabytes = defaultChunkMegabytes;

        protected override bool parameterIsCompulsory
        {
            get { return false; }
        }

        protected override void parameterIsSet()
        {
            if (parameter <= 0)
                throw new SyntaxException("The paramter to the /big option must be greater than zero");

            chunkMegabytes = parameter;
        }
    }
}
