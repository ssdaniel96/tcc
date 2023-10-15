using Repository.Context;

namespace Repository.Transactions;

public class Transaction : ITransaction
{
    private readonly ApplicationDbContext _applicationDbContext;

    public Transaction(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void BeginTransaction()
    {
        _applicationDbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        var currentTransaction = _applicationDbContext.Database.CurrentTransaction;

        if (currentTransaction == null)
            throw new ArgumentNullException("Transação está nula ao comitar!");

        currentTransaction.Commit();
    }

    public void RollbackTransaction()
    {
        var currentTransaction = _applicationDbContext.Database.CurrentTransaction;

        if (currentTransaction == null)
            throw new ArgumentNullException("Transação está nula ao realizar rollback!");

        currentTransaction.Rollback();    
    }
}