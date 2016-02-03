using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoEngine
{
    public static class Utils
    {
        public static void SafeDispose(IDisposable disposable)
        {
            if (disposable != null) disposable.Dispose();
        }
    }
}
