using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Common.Tests.Transactions
{
    public class StandardTransactionScope : ITransactionScope, IDisposable
    {
        TransactionScope transactionScope;

        public StandardTransactionScope()
        {
            transactionScope = new TransactionScope();
        }

        public StandardTransactionScope(TransactionScopeOption transactionScopeOption)
        {
            transactionScope = new TransactionScope(transactionScopeOption);
        }

        public StandardTransactionScope(TransactionScopeOption transactionScopeOption, TransactionOptions options)
        {
            transactionScope = new TransactionScope(transactionScopeOption, options);
        }



        public void Complete()
        {
            transactionScope.Complete();
        }

        public void Dispose()
        {
            transactionScope.Dispose();
        }
    }
}
