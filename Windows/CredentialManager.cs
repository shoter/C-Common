using CredentialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Common.Windows
{
    public class CredentialManager
    {
        public string Target { get; protected set; }
        public string Description { get; set; }
        public CredentialManager(string target, string description)
        {
            Target = target;
            Description = description;
        }

        public Credential LoadCredential()
        {
            var credential = new Credential { Target = Target };

            if (credential.Load() == false)
                throw new Exception("Credential has not been loaded");
            
            return credential;
        }

        public void SaveCredential(string username, string password, PersistanceType persistenceType, CredentialType credentialType = CredentialType.Generic)
        {
            var credential = new Credential
            {
                Target = Target,
                Username = username,
                Password = password,
                Description = Description,
                PersistanceType = persistenceType,
                Type = credentialType
            };

            if (credential.Save() == false)
                throw new Exception("Credential was not saved");

            credential.Dispose();
        }

        public void RemoveCredental()
        {
            var credential = new Credential { Target = Target };

            if (credential.Delete() == false)
                throw new Exception("Credential was not deleted");

            credential.Dispose();
        }
    }
}
