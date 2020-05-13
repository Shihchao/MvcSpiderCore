using Model.Test;
using System.Collections.Generic;
using Common.IOC;
using BLL.Implemention;
using Common.ExpressionExtend;

namespace BLL.Interface
{
    [Implement(typeof(TestBll_Imp))]
    public interface ITestBll
    {
        IEnumerable<TEST_MODEL> Query(IEnumerable<QueryParam> queryParams);

        int AddTestModel(TEST_MODEL model);

        int DelTestModel(string pkid);
    }
}
