﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class Account
    {
        public async static Task<IEnumerable<m.Account>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<m.Account>(DbAccess.SelectAll<m.Account>());
            }
        }

        public async static Task<m.Account> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<m.Account>(DbAccess.Select<m.Account>(),
                     new { AccountId = id });
            }
        }

        public async static Task Insert(m.Account obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<m.Account>(), obj);
            }
        }

        public async static Task Update(m.Account obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<m.Account>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<m.Account>(),
                    new { AccountId = id });
            }
        }

        public async static Task<decimal> GetBalance(Guid id)
        {
            decimal balance = 0;
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.QueryAsync("SELECT dbo.GetAccountBalance(@AccountId)",
                    new { AccountId = id });
            }

            return balance;
        }

        public async static Task<IEnumerable<m.AccountWithBalance>> GetAccountWithBalance(Guid ProfileId)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<m.AccountWithBalance>("SELECT AccountId, AccountName, AccountType, ProfileId, dbo.GetAccountBalance(AccountId) AS Balance FROM dbo.Account WHERE (ProfileId = @ProfileId)",
                     new { ProfileId = ProfileId });
            }
        }

    }
}
