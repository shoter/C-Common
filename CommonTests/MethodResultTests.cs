using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Operations;

namespace CommonTests
{
    [TestClass]
    public class MethodResultTests
    {
        [TestMethod]
        public void DefaultConstructorTest()
        {
            var def = new MethodResult();

            isSuccess(def);
        }

      

        [TestMethod]
        public void IsSuccessASuccessTest()
        {
            var suc = MethodResult.Success;

            isSuccess(suc);
        }

        [TestMethod]
        public void IsFailureAFailureTest()
        {
            var fail = MethodResult.Failure;

            isFailure(fail);
        }

        

        [TestMethod]
        public void SimpleFailureInitTest()
        {
            var errMsg = "Failure xd";
            var fail = new MethodResult(errMsg);

            Assert.IsFalse(fail.isSuccess);
            Assert.IsTrue(fail.IsError);
            Assert.AreEqual(1, fail.Errors.Count);
            Assert.AreEqual(errMsg, fail.Errors[0]);
        }

        [TestMethod]
        public void SimpleResultMadeToAFailureTest()
        {
            var res = new MethodResult();
            var errMsg = "Failure xd";
            res.AddError(errMsg);

            Assert.IsFalse(res.isSuccess);
            Assert.IsTrue(res.IsError);
            Assert.AreEqual(1, res.Errors.Count);
            Assert.AreEqual(errMsg, res.Errors[0]);
        }

        [TestMethod]
        public void SucessessMergeTest()
        {
            var suc1 = new MethodResult();
            var suc2 = new MethodResult();

            var merge = suc1.Merge(suc2);

            isSuccess(merge);
        }

        [TestMethod]
        public void FailuresMergeTest()
        {
            var msg1 = "xxx";
            var msg2 = "zzz";
            var fail1 = new MethodResult(msg1);
            var fail2 = new MethodResult(msg2);

            var merge = fail1.Merge(fail2);

            isFailure(merge);
            Assert.IsTrue(merge.Errors.Contains(msg1));
            Assert.IsTrue(merge.Errors.Contains(msg2));
        }

        [TestMethod]
        public void SuccessFailureMergeTest()
        {
            var msg = "xxx";
            var fail = new MethodResult(msg);
            var suc = new MethodResult();

            var merge = fail.Merge(suc);

            isFailure(merge);
            Assert.IsTrue(merge.Errors.Contains(msg));
        }

        private static void isSuccess(MethodResult def)
        {
            Assert.IsTrue(def.isSuccess);
            Assert.IsFalse(def.IsError);
            Assert.AreEqual(0, def.Errors.Count);
        }

        private static void isFailure(MethodResult fail)
        {
            Assert.IsFalse(fail.isSuccess);
            Assert.IsTrue(fail.IsError);
        }

    }
}
