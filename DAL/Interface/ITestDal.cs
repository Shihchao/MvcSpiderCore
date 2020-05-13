using Common.IOC;
using DAL.Base;
using DAL.Implemention;

namespace DAL.Interface
{
    [Implement(typeof(TestDal_Imp))]
    public interface ITestDal : IDal
    {
    }
}
