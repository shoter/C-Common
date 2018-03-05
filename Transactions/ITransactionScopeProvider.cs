using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Common.Transactions
{
    public interface ITransactionScopeProvider
    {
        TransactionScope CreateTransactionScope();

        TransactionScope CreateTransactionScope(TimeSpan timeout);

        TransactionScope CreateTransactionScope(IsolationLevel option, TimeSpan? timeout = null);

        TransactionScope CreateNewTransactionScope(IsolationLevel option, TimeSpan? timeout = null);

    }
}
