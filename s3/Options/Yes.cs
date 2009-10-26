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
            Console.WriteLine("The /yes option is not supported in the beta version, to avoid accidental deletions.");
            yesToAll = false;  // change to true on release
        }

        static internal bool confirm(string prompt)
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
