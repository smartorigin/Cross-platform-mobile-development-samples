using System;
using System.Runtime.InteropServices;
using sample.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(Sample_iOS))]
namespace sample.iOS
{
   public class Sample_iOS : ISum
    {
        [DllImport("__Internal")]
        private static extern int sum(int op1, int op2);

        public Sample_iOS()
        {
        }


        int ISum.sum(int a, int b)
        {
            return sum(a, b);
        }
    }
}
