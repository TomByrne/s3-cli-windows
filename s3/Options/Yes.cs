using System;
using System.Collections.Generic;
using System.Text;

namespace s3.Options
{
    class Yes : Option
    {
        static bool yesToAll = false;

        public Yes()
        {
            yesToAll = true;
        }

        static internal bool Confirm(string prompt)
        {
            if (yesToAll)
                return true;
            else
            {
                Console.Write(prompt + " ");
                return Console.ReadLine().StartsWith("y", StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}
