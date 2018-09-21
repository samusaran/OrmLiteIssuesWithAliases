using System;
using System.Configuration;
using System.Threading.Tasks;
using NUnit.Framework;
using ServiceStack.OrmLite;

namespace OrmLiteIssueWithAliases
{
    [TestFixture]
    public class Tests
    {
        public OrmLiteConnectionFactory factory;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            factory = new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider); // Insert the connection string you want

            using (var db = factory.OpenDbConnection())
            {
                db.DropAndCreateTable<MainTable>();
                db.DropAndCreateTable<AltTable>();
            }
        }
        
        [Test]
        public async Task Test_Aliases()
        {
            using (var db = factory.OpenDbConnection())
            {
                var q = db.From<MainTable>()
                    .Join<MainTable, AltTable>((mainTable, altTable) => mainTable.Id == altTable.Id)
                    .Where(x => x.Id == 1);

                var result = await db.RowCountAsync(q);
            }
        }
    }
}