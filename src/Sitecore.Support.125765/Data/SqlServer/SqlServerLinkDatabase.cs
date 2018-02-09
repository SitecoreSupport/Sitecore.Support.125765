using Sitecore.Data.Items;
using Sitecore.Data.SqlServer;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SqlServerLinkDatabaseOrigin = Sitecore.Data.SqlServer.SqlServerLinkDatabase;

namespace Sitecore.Support.Data.SqlServer
{
  public class SqlServerLinkDatabase : SqlServerLinkDatabaseOrigin
  {
    public SqlServerLinkDatabase(string connectionString) : base(connectionString) { }

    public override void UpdateItemVersionReferences(Item item)
    {
      Assert.ArgumentNotNull(item, "item");

      Task.Factory.StartNew(() =>
      {
        var links = item.Links.GetAllLinks(false);
        this.UpdateItemVersionLink(item, links);
      });
    }
  }
}