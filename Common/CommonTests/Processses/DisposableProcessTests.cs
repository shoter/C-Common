using Common.Processses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTests.Processses
{
    [TestClass]
    public class DisposableProcessTests
    {
        [TestMethod]
        public void TestDispose()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.Start();

   

            Assert.IsTrue(process.HasExited == false);

            using (new DisposableProcess(process)) { }

            Assert.IsTrue(process.HasExited == true);
        }

        [TestMethod]
        public void MakeDisposableTest()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.EnableRaisingEvents = true;
            process.Start();



            Assert.IsTrue(process.HasExited == false);

            using (process.MakeDisposable()) { }

            Assert.IsTrue(process.HasExited == true);
        }
    }
}
