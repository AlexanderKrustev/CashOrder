namespace CashOrder.Firms
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Models;
    using Models;

    public interface IFirmService
    {
        Task<IEnumerable<FirmListModel>> GetFirmsAsync();

        Task<FirmDetailsModel> CreateFirmAsync(CreateFirmModel model);

        Task<FirmDetailsModel> EditFirmAsync(FirmDetailsModel detailsModel, int firmId);

        
    }
}
