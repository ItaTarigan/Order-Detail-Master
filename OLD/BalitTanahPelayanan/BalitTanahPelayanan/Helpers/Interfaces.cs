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
        Task<bool> AddData(analysistypetbl obj);
        Task<bool> UpdateData(string id, analysistypetbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<analysistypetbl>> GetData();
        Task<analysistypetbl> DetailData(string id);
        Task<IEnumerable<analysistypetbl>> GetDataByContaint(string param);
    }

    public interface IOrderSampleMasterData
    {
        Task<IEnumerable<ordersampletbl>> GetDataAsync(string id);
    }

    public interface IOrderAnalysisMasterData
    {
        Task<IEnumerable<orderanalysisdetailtbl>> GetData(string id);
    }

    public interface IComodityMasterData
    {
        Task<bool> AddData(comoditytbl obj);
        Task<bool> UpdateData(string id, comoditytbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<comoditytbl>> GetData();
        Task<comoditytbl> DetailData(string id);
        Task<IEnumerable<comoditytbl>> GetDataByContaint(string param);
    }

    public interface IEmployeeMasterData
    {
        Task<bool> AddData(employeetbl obj);
        Task<bool> UpdateData(string id, employeetbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<employeetbl>> GetData();
        Task<employeetbl> DetailData(string id);
        Task<IEnumerable<employeetbl>> GetDataByContaint(string param);
        Task<IEnumerable<employeetbl>> GetDataAnalis(string Lab="");
    }

    public interface IAccountMasterData
    {
        Task<bool> AddData(accounttbl obj);
        Task<bool> UpdateData(string id, accounttbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<accounttbl>> GetData();
        Task<accounttbl> DetailData(string id);
        Task<IEnumerable<accounttbl>> GetDataByContaint(string param);
    }

    public interface IRoleMasterData
    {
        Task<bool> AddData(roletbl obj);
        Task<bool> UpdateData(string id, roletbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<roletbl>> GetData();
        Task<roletbl> DetailData(string id);
        Task<IEnumerable<roletbl>> GetDataByContaint(string param);
    }

    public interface ICustomerMasterData
    {
        Task<bool> AddData(customertbl obj);
        Task<bool> UpdateData(string id, customertbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<customertbl>> GetData();
        Task<customertbl> DetailData(string id);
        Task<IEnumerable<customertbl>> GetDataByContaint(string param);
    }

    public interface IElementServicesMasterData
    {
        Task<bool> AddData(elementservicestbl obj);
        Task<bool> UpdateData(string id, elementservicestbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<elementservicestbl>> GetData();
        Task<elementservicestbl> DetailData(string id);
        Task<IEnumerable<elementservicestbl>> GetDataByContaint(string param);
    }
    

    public interface IOrderListMasterData
    {
        Task<IEnumerable<ordermastertbl>> GetData(string Lab="");
        Task<ordermastertbl> DetailData(string id);
        Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param);
    }

    public interface ICustomerOrderProcessMasterData
    {
        Task<IEnumerable<ordermastertbl>> GetData();
        Task<ordermastertbl> DetailData(int id);
        Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param);
    }

    public interface ICustomerRincianMasterData
    {
        Task<IEnumerable<ordersampletbl>> GetData();
        Task<ordersampletbl> DetailData(int id);
        Task<IEnumerable<ordersampletbl>> GetDataByContaint(string param);
    }

    public interface IStandardMasterData
    {
        Task<bool> AddData(standardtbl obj);
        Task<bool> UpdateData(string id, standardtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<standardtbl>> GetData();
        Task<standardtbl> DetailData(string id);
        Task<IEnumerable<standardtbl>> GetDataByContaint(string param);
    }

    public interface IStandardDetailMasterData
    {
        Task<bool> AddData(standarddetailtbl obj);
        Task<bool> UpdateData(string id, standarddetailtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<standarddetailtbl>> GetData();
        Task<standarddetailtbl> DetailData(string id);
        Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IOrderMasterMasterData
    {
        Task<bool> AddData(ordermastertbl obj);
        Task<bool> UpdateData(string id, ordermastertbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<ordermastertbl>> GetData();
        Task<ordermastertbl> DetailData(string id);
        Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param);
    }

    public interface IOrderDetailMasterData
    {
        Task<bool> AddData(orderanalysisdetailtbl obj);
        Task<bool> UpdateData(string id, orderanalysisdetailtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<orderanalysisdetailtbl>> GetData();
        Task<orderanalysisdetailtbl> DetailData(string id);
        Task<IEnumerable<orderanalysisdetailtbl>> GetDataByContaint(string param);
    }

    public interface ISampleMasterData
    {
        Task<bool> AddData(ordersampletbl obj);
        Task<bool> UpdateData(string id, ordersampletbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<ordersampletbl>> GetData();
        Task<ordersampletbl> DetailData(string id);
        Task<IEnumerable<ordersampletbl>> GetDataByContaint(string param);
    }

    public interface ILoglMasterData
    {
        //Task<bool> AddData(standarddetailtbl obj);
        //Task<bool> UpdateData(string id, standarddetailtbl obj);
        //Task<bool> DeleteData(string id);
        Task<IEnumerable<logtbl>> GetData();
        //Task<standarddetailtbl> DetailData(string id);
        //Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IWorkflowMasterData
    {
        //Task<bool> AddData(standarddetailtbl obj);
        //Task<bool> UpdateData(string id, standarddetailtbl obj);
        //Task<bool> DeleteData(string id);
        Task<IEnumerable<workflowlogtbl>> GetData();
        //Task<standarddetailtbl> DetailData(string id);
        //Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IResultMasterData
    {
        //Task<bool> AddData(standarddetailtbl obj);
        //Task<bool> UpdateData(string id, standarddetailtbl obj);
        //Task<bool> DeleteData(string id);
        Task<IEnumerable<resulttbl>> GetData();
        //Task<standarddetailtbl> DetailData(string id);
        //Task<IEnumerable<standarddetailtbl>> GetDataByContaint(string param);
    }

    public interface IParameterMasterData
    {
        Task<bool> AddData(parameterstbl obj);
        Task<bool> UpdateData(string id, parameterstbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<parameterstbl>> GetData();
        Task<parameterstbl> DetailData(string id);
        Task<IEnumerable<parameterstbl>> GetDataByContaint(string param);
    }

    public interface IRegisterFormData
    {
        Task<bool> AddData(accounttbl obj);
        Task<bool> AddData2(customertbl obj);
    }

    public interface IReviewingMasterData
    {
        Task<bool> AddData(reviewingtbl obj);
        Task<bool> UpdateData(string id, reviewingtbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<reviewingtbl>> GetData();
        Task<reviewingtbl> DetailData(string id);
        Task<IEnumerable<reviewingtbl>> GetDataByContaint(string param);
    }

    public interface IManagerTeknisSelesaiMasterData
    {
        Task<IEnumerable<ordermastertbl>> GetData();
        Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param);
        Task<ordermastertbl> GetDataFile(string id);
    }

    public interface IOrderMasterData
    {
        Task<IEnumerable<ordermastertbl>> GetData();
        Task<ordermastertbl> DetailData(int id);
        Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param);
        Task<IEnumerable<ordermastertbl>> GetDataBaru();
    }

    public interface ICashierMasterData
    {
        Task<IEnumerable<ordermastertbl>> GetData();
        Task<ordermastertbl> DetailData(int id);
        Task<IEnumerable<ordermastertbl>> GetDataByContaint(string param);
    }
}
