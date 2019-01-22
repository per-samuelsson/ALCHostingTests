using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace App
{
    class NativeMethods
    {
        [DllImport("libswipl")]
		public static extern int PL_is_initialised(IntPtr argc, IntPtr argv);
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Assure compiler emit reference
            Console.WriteLine(Starcounter.QueryProcessor.Db.NullString);

            var result = NativeMethods.PL_is_initialised(IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine(result);
        }
    }
}