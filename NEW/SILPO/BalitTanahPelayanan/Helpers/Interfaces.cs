using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalitTanahPelayanan.Models;

namespace BalitTanahPelayanan.Helpers
{
    public interface IAnalysisTypeMasterData
    {
        Task<bool> AddData(Analysistypetbl obj);
        Task<bool> UpdateData(string id, Analysistypetbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Analysistypetbl>> GetData();
        Task<Analysistypetbl> DetailData(string id);
        Task<IEnumerable<Analysistypetbl>> GetDataByContaint(string param);
    }

    public interface IOrderSampleMasterData
    {
        Task<IEnumerable<Ordersampletbl>> GetDataAsync(string id);
    }

    public interface IOrderAnalysisMasterData
    {
        Task<IEnumerable<Orderanalysisdetailtbl>> GetData(string id);
    }

    public interface IComodityMasterData
    {
        Task<bool> AddData(Comoditytbl obj);
        Task<bool> UpdateData(string id, Comoditytbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Comoditytbl>> GetData();
        Task<Comoditytbl> DetailData(string id);
        Task<IEnumerable<Comoditytbl>> GetDataByContaint(string param);
    }

    public interface IEmployeeMasterData
    {
        Task<bool> AddData(Employeetbl obj);
        Task<bool> UpdateData(string id, Employeetbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Employeetbl>> GetData();
        Task<Employeetbl> DetailData(string id);
        Task<IEnumerable<Employeetbl>> GetDataByContaint(string param);
        Task<IEnumerable<Employeetbl>> GetDataAnalis(string Lab="");
    }

    public interface IAccountMasterData
    {
        Task<bool> AddData(Accounttbl obj);
        Task<bool> UpdateData(string id, Accounttbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Accounttbl>> GetData();
        Task<Accounttbl> DetailData(string id);
        Task<IEnumerable<Accounttbl>> GetDataByContaint(string param);
    }

    public interface IRoleMasterData
    {
        Task<bool> AddData(Roletbl obj);
        Task<bool> UpdateData(string id, Roletbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Roletbl>> GetData();
        Task<Roletbl> DetailData(string id);
        Task<IEnumerable<Roletbl>> GetDataByContaint(string param);
    }

    public interface ICustomerMasterData
    {
        Task<bool> AddData(Customertbl obj);
        Task<bool> UpdateData(string id, Customertbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Customertbl>> GetData();
        Task<Customertbl> DetailData(string id);
        Task<IEnumerable<Customertbl>> GetDataByContaint(string param);
    }

    public interface IElementServicesMasterData
    {
        Task<bool> AddData(Elementservicestbl obj);
        Task<bool> UpdateData(string id, Elementservicestbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Elementservicestbl>> GetData();
        Task<Elementservicestbl> DetailData(string id);
        Task<IEnumerable<Elementservicestbl>> GetDataByContaint(string param);
    }
    

    public interface IOrderListMasterData
    {
        Task<IEnumerable<Ordermastertbl>> GetData(string Lab="");
        Task<Ordermastertbl> DetailData(string id);
        Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param);
    }

    public interface ICustomerOrderProcessMasterData
    {
        Task<IEnumerable<Ordermastertbl>> GetData();
        Task<Ordermastertbl> DetailData(int id);
        Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param);
    }

    public interface ICustomerRincianMasterData
    {
        Task<IEnumerable<Ordersampletbl>> GetData();
        Task<Ordersampletbl> DetailData(int id);
        Task<IEnumerable<Ordersampletbl>> GetDataByContaint(string param);
    }

    public interface IStandardMasterData
    {
        Task<bool> AddData(Standardtbl obj);
        Task<bool> UpdateData(string id, Standardtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Standardtbl>> GetData();
        Task<Standardtbl> DetailData(string id);
        Task<IEnumerable<Standardtbl>> GetDataByContaint(string param);
    }

    public interface IStandardDetailMasterData
    {
        Task<bool> AddData(Standarddetailtbl obj);
        Task<bool> UpdateData(string id, Standarddetailtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Standarddetailtbl>> GetData();
        Task<Standarddetailtbl> DetailData(string id);
        Task<IEnumerable<Standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IOrderMasterMasterData
    {
        Task<bool> AddData(Ordermastertbl obj);
        Task<bool> UpdateData(string id, Ordermastertbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Ordermastertbl>> GetData();
        Task<Ordermastertbl> DetailData(string id);
        Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param);
    }

    public interface IOrderDetailMasterData
    {
        Task<bool> AddData(Orderanalysisdetailtbl obj);
        Task<bool> UpdateData(string id, Orderanalysisdetailtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Orderanalysisdetailtbl>> GetData();
        Task<Orderanalysisdetailtbl> DetailData(string id);
        Task<IEnumerable<Orderanalysisdetailtbl>> GetDataByContaint(string param);
    }

    public interface ISampleMasterData
    {
        Task<bool> AddData(Ordersampletbl obj);
        Task<bool> UpdateData(string id, Ordersampletbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Ordersampletbl>> GetData();
        Task<Ordersampletbl> DetailData(string id);
        Task<IEnumerable<Ordersampletbl>> GetDataByContaint(string param);
    }

    public interface ILoglMasterData
    {
        //Task<bool> AddData(standarddetailtbl obj);
        //Task<bool> UpdateData(string id, standarddetailtbl obj);
        //Task<bool> DeleteData(string id);
        Task<IEnumerable<Logtbl>> GetData();
        //Task<standarddetailtbl> DetailData(string id);
        //Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IWorkflowMasterData
    {
        //Task<bool> AddData(standarddetailtbl obj);
        //Task<bool> UpdateData(string id, standarddetailtbl obj);
        //Task<bool> DeleteData(string id);
        Task<IEnumerable<Workflowlogtbl>> GetData();
        //Task<standarddetailtbl> DetailData(string id);
        //Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IResultMasterData
    {
        //Task<bool> AddData(standarddetailtbl obj);
        //Task<bool> UpdateData(string id, standarddetailtbl obj);
        //Task<bool> DeleteData(string id);
        Task<IEnumerable<Resulttbl>> GetData();
        //Task<standarddetailtbl> DetailData(string id);
        //Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IParameterMasterData
    {
        Task<bool> AddData(Parameterstbl obj);
        Task<bool> UpdateData(string id, Parameterstbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Parameterstbl>> GetData();
        Task<Parameterstbl> DetailData(string id);
        Task<IEnumerable<Parameterstbl>> GetDataByContaint(string param);
    }

    public interface IRegisterFormData
    {
        Task<bool> AddData(Accounttbl obj);
        Task<bool> AddData2(Customertbl obj);
    }

    public interface IReviewingMasterData
    {
        Task<bool> AddData(Reviewingtbl obj);
        Task<bool> UpdateData(string id, Reviewingtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<Reviewingtbl>> GetData();
        Task<Reviewingtbl> DetailData(string id);
        Task<IEnumerable<Reviewingtbl>> GetDataByContaint(string param);
    }

    public interface IManagerTeknisSelesaiMasterData
    {
        Task<IEnumerable<Ordermastertbl>> GetData();
        Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param);
        Task<Ordermastertbl> GetDataFile(string id);
    }

    public interface IOrderMasterData
    {
        Task<IEnumerable<Ordermastertbl>> GetData();
        Task<Ordermastertbl> DetailData(int id);
        Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param);
        Task<IEnumerable<Ordermastertbl>> GetDataBaru();
    }

    public interface ICashierMasterData
    {
        Task<IEnumerable<Ordermastertbl>> GetData();
        Task<Ordermastertbl> DetailData(int id);
        Task<IEnumerable<Ordermastertbl>> GetDataByContaint(string param);
    }
}
