using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Common.EntityFrameworkFExtend
{
    public static class ModelRegister
    {
        public static void Regist(ModelBuilder modelBuilder, string nameSpace)
        {
            var a = Assembly.GetCallingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace) && type.Namespace.StartsWith(nameSpace));

            var b = a.Where(type => GenericTypeEqual(type, (typeof(IEntityTypeConfiguration<>))));

            var typesToRegister = Assembly.GetCallingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace) && type.Namespace.StartsWith(nameSpace))
           .Where(type => InterfaceEqual(type, (typeof(IEntityTypeConfiguration<>))));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

        /// <summary>
        /// 递归调用 判断类或其基类是否为指定泛型类
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool GenericTypeEqual(Type type, Type equalType)
        {
            if (type == null || equalType == null)
                return false;
            if (type.IsGenericType && type.GetGenericTypeDefinition() == equalType)
                return true;
            return GenericTypeEqual(type.BaseType, equalType);
        }

        /// <summary>
        /// 递归调用 判断类所实现的接口是否为指定接口
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool InterfaceEqual(Type type, Type equalType)
        {
            if (type == null || equalType == null)
                return false;

            return type.GetInterface(equalType.Name) != null;
        }
    }
}
