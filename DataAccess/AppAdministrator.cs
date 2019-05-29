using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class AppAdministrator
    {
        public async static Task<IEnumerable<m.AppAdministrator>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<m.AppAdministrator>(DbAccess.SelectAll<m.AppAdministrator>());
            }
        }

        public async static Task<m.AppAdministrator> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<m.AppAdministrator>(DbAccess.Select<m.AppAdministrator>(),
                     new { AppAdministratorId = id });
            }
        }

        public async static Task Insert(m.AppAdministrator obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<m.AppAdministrator>(), obj);
            }
        }

        public async static Task Update(m.AppAdministrator obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<m.AppAdministrator>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<m.AppAdministrator>(),
                    new { AppAdministratorId = id });
            }
        }
    }
}
