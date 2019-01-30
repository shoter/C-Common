using Elmah;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Common
{
    public class TransactionUtils
    {
        public static IsolationLevel? GetCurrentIsolationLevel(){
            Transaction trans = Transaction.Current;
            return trans?.IsolationLevel;
        
        }

        public static void DebugTransaction(Transaction transaction)
        {
            transaction.TransactionCompleted += Transaction_TransactionCompleted;
        }

        private static void Transaction_TransactionCompleted(object sender, TransactionEventArgs e)
        {
            if (e.Transaction.TransactionInformation.Status == TransactionStatus.Aborted)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
#if !DEBUG
                string message = new System.Diagnostics.StackTrace().ToString();
                message += "<br/>";
                message += $"Isolation = {e.Transaction.IsolationLevel.ToString()}<br/>";
                message += $"Status = {e.Transaction.TransactionInformation.Status}<br/>";
                Elmah.ErrorLog.GetDefault(null).Log(new Error(new Exception(message)));
#endif
            }
        }
    }
}
