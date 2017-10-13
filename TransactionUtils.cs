using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Common
{
    public class TransactionUtils
    {
        public static TransactionScope CreateTransactionScope()
        {
            return CreateTransactionScope(TransactionScopeOption.Required);
        }

        public static TransactionScope CreateTransactionScope(TimeSpan timeout)
        {
            return CreateTransactionScope(TransactionScopeOption.Required, timeout);
        }

        public static TransactionScope CreateTransactionScope(TransactionScopeOption option, TimeSpan? timeout = null)
        {
            var transactionOptions = new TransactionOptions();
            if(timeout != null)
                transactionOptions.Timeout = timeout.Value;
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;
            return new TransactionScope(option, transactionOptions);
        }

        public static TransactionScope CreateTransactionScope(IsolationLevel isolationLevel, TimeSpan? timeout = null)
        {
            var transactionOptions = new TransactionOptions();
            if (timeout != null)
                transactionOptions.Timeout = timeout.Value;
            transactionOptions.IsolationLevel = isolationLevel;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        public static TransactionScope CreateTransactionScopeIfNotActive(IsolationLevel isolationLevel, TimeSpan? timeout = null)
        {
            if (System.Transactions.Transaction.Current == null)
                return CreateTransactionScope(isolationLevel, timeout);
            return null;
        }
    }
}
