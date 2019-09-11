﻿using System;
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
        public async static Task<IEnumerable<m.DailyTransaction>> Get()
        {
            IEnumerable<m.Category> categories = await Category.Get();
            IEnumerable<m.Account> accounts = await Account.Get();

            using (var db = DbAccess.ConnectionFactory())
            {
                IEnumerable<m.DailyTransaction> transactions = await db.QueryAsync<m.DailyTransaction>(DbAccess.SelectAll<m.DailyTransaction>());
                foreach (var t in transactions)
                {
                    t.Category = categories.FirstOrDefault(c => c.CategoryId == t.CategoryId);
                    t.Account = accounts.FirstOrDefault(a => a.AccountId == t.AccountId);
                }

                return transactions;
            }
        }

        public async static Task<IEnumerable<m.DailyTransaction>> GetByProfileId(Guid ProfileId)
        {
            IEnumerable<m.Category> categories = await Category.Get();
            IEnumerable<m.Account> accounts = await Account.Get();

            using (var db = DbAccess.ConnectionFactory())
            {
                IEnumerable<m.DailyTransaction> transactions = await db.QueryAsync<m.DailyTransaction>(DbAccess.SelectAll<m.DailyTransaction>() + " WHERE AccountId IN (SELECT AccountId FROM Account WHERE ProfileId=@ProfileId) ORDER BY TransactionDate", 
                    new { ProfileId = ProfileId });

                foreach (var t in transactions)
                {
                    t.Category = categories.FirstOrDefault(c => c.CategoryId == t.CategoryId);
                    t.Account = accounts.FirstOrDefault(a => a.AccountId == t.AccountId);
                }

                return transactions;
            }
        }

        public async static Task<IEnumerable<m.DailyTransaction>> GetByProfileId(Guid ProfileId, DateTime _start, DateTime _end)
        {
            IEnumerable<m.Category> categories = await Category.Get();
            IEnumerable<m.Account> accounts = await Account.Get();

            using (var db = DbAccess.ConnectionFactory())
            {
                IEnumerable<m.DailyTransaction> transactions = await db.QueryAsync<m.DailyTransaction>(DbAccess.SelectAll<m.DailyTransaction>() +
                    " WHERE ([TransactionDate] BETWEEN @s AND @e) AND (AccountId IN (SELECT AccountId FROM Account WHERE ProfileId=@ProfileId)) ORDER BY TransactionDate",
                    new { s=_start, e=_end, ProfileId = ProfileId });

                foreach (var t in transactions)
                {
                    t.Category = categories.FirstOrDefault(c => c.CategoryId == t.CategoryId);
                    t.Account = accounts.FirstOrDefault(a => a.AccountId == t.AccountId);
                }

                return transactions;
            }
        }

        public async static Task<m.DailyTransaction> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                m.DailyTransaction transaction = await db.QueryFirstOrDefaultAsync<m.DailyTransaction>(DbAccess.Select<m.DailyTransaction>(),
                     new { TransactionId = id });

                transaction.Category = await Category.Get(transaction.CategoryId);
                transaction.Account = await Account.Get(transaction.AccountId);

                return transaction;
            }
        }

        public async static Task Insert(m.DailyTransaction obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<m.DailyTransaction>(), obj);
            }
        }

        public async static Task Update(m.DailyTransaction obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<m.DailyTransaction>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<m.DailyTransaction>(),
                    new { TransactionId = id });
            }
        }
    }
}
