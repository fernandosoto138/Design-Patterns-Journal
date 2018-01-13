using Xunit;
using System.IO;
using System.Threading;

namespace Singleton_CS_1
{
    public class Test_SuperLogSingleton
    {
        [Fact]
        public void Single_Thread_Test()
        {
            SuperLogSingleton sl1 = SuperLogSingleton.Instance;
            sl1.AddLine("I'm the first line");
            SuperLogSingleton sl2 = SuperLogSingleton.Instance;
            sl2.AddLine("I'm supposed to be the second line");
            Assert.Equal(sl1.Output,sl2.Output);
        }
        [Fact]
        public void MultiTread_Test()
        {
            SuperLogSingleton sl1 = SuperLogSingleton.Instance;
            sl1.AddLine("I'm the first line");
            var output1 = sl1.Output;
            var process = new OtherThread();
            Thread thread1 = new Thread( new ThreadStart(process.SimpleMethod));
            thread1.Start();
            //Waits until the thread ends
            thread1.Join();
            Assert.Equal(output1 + "I'm the second line\n",sl1.Output);

        }

        class OtherThread 
        {
            public void SimpleMethod()
            {
                SuperLogSingleton sl2 = SuperLogSingleton.Instance;
                sl2.AddLine("I'm the second line");
            }
        }

    }
}