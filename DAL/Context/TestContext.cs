using DAL.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public partial class TestContext
    {
        private static string configName = "TestContext";
        private static string mappingsPath = "DAL.DomainMappings";
    }

    public partial class TestContext : BaseContext
    {
        public TestContext() : base(configName, mappingsPath) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
