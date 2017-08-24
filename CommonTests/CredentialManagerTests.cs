using Common.Windows;
using CredentialManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CommonTests
{
    [TestClass]
    public class CredentialManagerTests
    {
        CredentialManager manager = new CredentialManager(
            target: "CredentialManagerTests",
            description: "Credentials used only for tests"
            );

        string username = "TestUsername";
        string password = "SomeWeirdPassword";

        [TestMethod]
        public void SaveLoadTest()
        {
            manager.SaveCredential(username, password, PersistanceType.LocalComputer, CredentialType.Generic);

            var credentials = manager.LoadCredential();

            Assert.AreEqual(username, credentials.Username);
            Assert.AreEqual(password, credentials.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaveRemoveTest()
        {
            manager.SaveCredential(username, password, PersistanceType.LocalComputer, CredentialType.Generic);
            manager.RemoveCredental();

            manager.LoadCredential();
        }
    }
}
