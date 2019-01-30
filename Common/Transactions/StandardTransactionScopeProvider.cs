using Common.Tests.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Common.Transactions
{
    public class StandardTransactionScopeProvider : ITransactionScopeProvider
    {
#if DEBUG
        private static int maxTimeout = 60;
#else
        private static int maxTimeout = 20;
#endif

        public ITransactionScope CreateTransactionScope()
        {
            return CreateTransactionScope(IsolationLevel.ReadCommitted);
        }

        public ITransactionScope CreateTransactionScope(TimeSpan timeout)
        {
            return CreateTransactionScope(IsolationLevel.ReadCommitted, timeout);
        }

        public ITransactionScope CreateTransactionScope(IsolationLevel isolationLevel, TimeSpan? timeout = null)
        {
            TransactionOptions transactionOptions = createTransactionOptions(ref isolationLevel, timeout);
            var trs = new StandardTransactionScope(TransactionScopeOption.Required, transactionOptions);
            debugCurrentTransaction();
            return trs;
        }

        private static void debugCurrentTransaction()
        {
            TransactionUtils.DebugTransaction(Transaction.Current);
        }

        public ITransactionScope CreateNewTransactionScope(IsolationLevel isolationLevel, TimeSpan? timeout = null)
        {
            TransactionOptions transactionOptions = createTransactionOptions(ref isolationLevel, timeout);
            var trs = new StandardTransactionScope(TransactionScopeOption.RequiresNew, transactionOptions);
            debugCurrentTransaction();
            return trs;
        }

        private static TransactionOptions createTransactionOptions(ref IsolationLevel isolationLevel, TimeSpan? timeout)
        {
            var transactionOptions = new TransactionOptions();
            if (timeout != null)
                transactionOptions.Timeout = timeout.Value;
            else
                transactionOptions.Timeout = new TimeSpan(0, 0, 0, maxTimeout);

            var curIs = TransactionUtils.GetCurrentIsolationLevel();
            if (curIs != null && curIs != isolationLevel)
                isolationLevel = curIs.Value;

            transactionOptions.IsolationLevel = isolationLevel;
            return transactionOptions;
        }
    }
}
