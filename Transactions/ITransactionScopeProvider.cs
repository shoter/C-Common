using Common.Tests.Transactions;
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
        ITransactionScope CreateTransactionScope();

        ITransactionScope CreateTransactionScope(TimeSpan timeout);

        ITransactionScope CreateTransactionScope(IsolationLevel option, TimeSpan? timeout = null);

        ITransactionScope CreateNewTransactionScope(IsolationLevel option, TimeSpan? timeout = null);

    }
}
