using System;
using System.Collections.Generic;
using System.Text;

namespace s3 {
    
    static class ExecutionEnvironment {

        public static bool IsMono {
            get {
                return Type.GetType ("Mono.Runtime") != null;
            }
        }

        public static bool IsLinux {
            get {
                int p = (int)Environment.OSVersion.Platform;
                return ((p == 4) || (p == 128));
            }
        }

    }
}
