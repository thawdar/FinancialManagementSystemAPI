using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using System.Linq;
using m = Model;

namespace DataAccess
{
    public class Profile
    {
        public async static Task<IEnumerable<m.Profile>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<m.Profile>(DbAccess.SelectAll<m.Profile>());
            }
        }

        public async static Task<m.Profile> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<m.Profile>(DbAccess.Select<m.Profile>(),
                     new { ProfileId = id });
            }
        }

        public async static Task<m.Profile> Login(m.Profile p)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                string query = DbAccess.SelectAll<m.Profile>() + " WHERE [LoginId]=@LoginId AND [Pwd]=@Pwd";
                m.Profile profile =  await db.QueryFirstOrDefaultAsync<m.Profile>(query,
                     new { LoginId= p.LoginId, Pwd = p.Pwd});

                return profile;
            }
        }

        public async static Task Insert(m.Profile obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<m.Profile>(), obj);
            }
        }

        public async static Task Update(m.Profile obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<m.Profile>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<m.Profile>(),
                    new { ProfileId = id });
            }
        }
    }
}
