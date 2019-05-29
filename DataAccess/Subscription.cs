using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class Subscription
    {
        public async static Task<IEnumerable<m.Subscription>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<m.Subscription>(DbAccess.SelectAll<m.Subscription>());
            }
        }

        public async static Task<m.Subscription> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<m.Subscription>(DbAccess.Select<m.Subscription>(),
                     new { SubscriptionId = id });
            }
        }

        public async static Task Insert(m.Subscription obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<m.Subscription>(), obj);
            }
        }

        public async static Task Update(m.Subscription obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<m.Subscription>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<m.Subscription>(),
                    new { SubscriptionId = id });
            }
        }
    }
}
