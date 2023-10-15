namespace Repository.Transactions;

public interface ITransaction
{
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}