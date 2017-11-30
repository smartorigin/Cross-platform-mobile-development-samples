using System;
using System.Runtime.InteropServices;
using sample.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Sample_Android))]
namespace sample.Droid
{
    public class Sample_Android : ISum
        {

            [DllImport("native")]
            private static extern int sum(int op1, int op2);

            public Sample_Android()
            {
            }

            int ISum.sum(int a, int b)
            {
                return sum(a, b);
            }
        }
}
