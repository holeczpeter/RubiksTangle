using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksTangle.Core
{
    public class RubikDbContextFactory : IDesignTimeDbContextFactory<RubikDbContext>
    {
        public RubikDbContext CreateDbContext(string[] args)
        {
            var contextBuilder = new DbContextOptionsBuilder<RubikDbContext>();
            contextBuilder.UseSqlServer("Server=DESKTOP-QMEJOI6\\SQLEXPRESS;Database=RubiksTangle;Integrated Security=SSPI;MultipleActiveResultSets=true;");
            return new RubikDbContext(contextBuilder.Options);
        }
    }
}
