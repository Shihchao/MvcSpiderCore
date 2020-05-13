using Common.ExpressionExtend;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Base
{
    public interface IDal
    {
        /// <summary>
        /// 通用查询方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ps"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(IEnumerable<QueryParam> ps) where T : BaseModel;

        /// <summary>
        /// 通用添加方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public IDal Add<T>(T model) where T : BaseModel;

        /// <summary>
        /// 通用删除方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public IDal Del<T>(string pkid) where T : BaseModel;

        /// <summary>
        /// 通用范围删除方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public IDal DelRange<T>(IEnumerable<string> pkids) where T : BaseModel;

        /// <summary>
        /// 通用查找方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public T Find<T>(string pkid) where T : BaseModel;

        /// <summary>
        /// 保存
        /// </summary>
        public int SaveChanges();


        public void Dispose();
    }
}
