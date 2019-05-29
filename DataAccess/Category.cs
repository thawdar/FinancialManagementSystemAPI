using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class Category
    {
        public async static Task<IEnumerable<m.Category>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<m.Category>(DbAccess.SelectAll<m.Category>());
            }
        }

        public async static Task<m.Category> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<m.Category>(DbAccess.Select<m.Category>(),
                     new { CategoryId = id });
            }
        }

        public async static Task Insert(m.Category obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<m.Category>(), obj);
            }
        }

        public async static Task Update(m.Category obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<m.Category>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<m.Category>(),
                    new { CategoryId = id });
            }
        }
    }
}
