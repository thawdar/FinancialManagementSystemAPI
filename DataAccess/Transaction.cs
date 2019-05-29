using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;
using System.Linq;

namespace DataAccess
{
    public class Transaction
    {
        public async static Task<IEnumerable<m.Transaction>> Get()
        {
            IEnumerable<m.Category> categories = await Category.Get();
            IEnumerable<m.Account> accounts = await Account.Get();

            using (var db = DbAccess.ConnectionFactory())
            {
                IEnumerable<m.Transaction> transactions = await db.QueryAsync<m.Transaction>(DbAccess.SelectAll<m.Transaction>());
                foreach (var t in transactions)
                {
                    t.Category = categories.FirstOrDefault(c => c.CategoryId == t.CategoryId);
                    t.Account = accounts.FirstOrDefault(a => a.AccountId == t.AccountId);
                }

                return transactions;
            }
        }

        public async static Task<m.Transaction> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                m.Transaction transaction = await db.QueryFirstOrDefaultAsync<m.Transaction>(DbAccess.Select<m.Transaction>(),
                     new { TransactionId = id });

                transaction.Category = await Category.Get(transaction.CategoryId);
                transaction.Account = await Account.Get(transaction.AccountId);

                return transaction;
            }
        }

        public async static Task Insert(m.Transaction obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<m.Transaction>(), obj);
            }
        }

        public async static Task Update(m.Transaction obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<m.Transaction>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<m.Transaction>(),
                    new { TransactionId = id });
            }
        }
    }
}
