namespace CashOrder.Firms
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FirmServices : IFirmService
    {
        private readonly CoDbContext _data;

        public FirmServices(CoDbContext data)
        {
            this._data = data;
        }

        public async Task<IEnumerable<FirmListModel>> GetFirmsAsync()
            => await this._data.Firms.Select(f =>
                new FirmListModel()
                {
                    Name = f.Name
                }).ToListAsync();
        

        public async Task<FirmDetailsModel> CreateFirmAsync(CreateFirmModel model)
        {
            var firm = new FirmEntityModel()
            {
                Address = model.Address,
                Name = model.Name,
                Vat = model.Vat
            };
           

            await this._data.Firms.AddAsync(firm);
           await this._data.SaveChangesAsync();

           var editedFirm = new FirmDetailsModel()
           {
               Address = firm.Address,
               Id = firm.Id,
               Name = firm.Name,
               Vat = firm.Vat
           };

            return editedFirm;

        }

        public async Task<FirmDetailsModel> EditFirmAsync(FirmDetailsModel detailsModel, int id)
        {
            var firm = await this._data.Firms.FirstOrDefaultAsync(c=>c.Id==id);

            firm.Vat = detailsModel.Vat;
            firm.Address = detailsModel.Address;
            firm.Name = detailsModel.Name;

            var editedFirm = new FirmDetailsModel()
            {
                Address = firm.Address,
                Id = detailsModel.Id,
                Name = detailsModel.Name,
                Vat = detailsModel.Vat
            };

            await this._data.SaveChangesAsync();

            return editedFirm;

        }

       
    
    }
}
