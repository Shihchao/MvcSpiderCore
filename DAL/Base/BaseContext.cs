using Common.EntityFrameworkFExtend;
using Common.Tool;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base
{
    /// <summary>
    /// Core的Code-First模式要手动操作，所以这个demo需要自己手动创建表
    /// </summary>
    public class BaseContext : DbContext
    {
        string mappingPath;
        string configName;

        public BaseContext(string configName, string mappingPath) : base()
        {
            this.mappingPath = mappingPath;
            this.configName = configName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConfigurationManager.GetConfiguration().GetConnectionString(configName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelRegister.Regist(modelBuilder, mappingPath);
            base.OnModelCreating(modelBuilder);
        }
    }
}
