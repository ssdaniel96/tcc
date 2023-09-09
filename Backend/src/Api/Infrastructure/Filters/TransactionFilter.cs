using Microsoft.AspNetCore.Mvc.Filters;
using Repository.Transactions;

namespace Api.Infrastructure.Filters;

public class TransactionFilter : IActionFilter
{
    private readonly ITransaction _transaction;

    public TransactionFilter(ITransaction transaction)
    {
        _transaction = transaction;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _transaction.BeginTransaction();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null)
        {
            _transaction.CommitTransaction();
        }
        else
        {
            _transaction.RollbackTransaction();
        }
    }
}