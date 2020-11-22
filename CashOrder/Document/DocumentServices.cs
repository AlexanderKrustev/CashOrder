namespace CashOrder.Document
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Firms;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DocumentServices : IDocumentService
    {
        private readonly CoDbContext _data;
        private readonly IFirmService _firmservice;

        public DocumentServices(CoDbContext data, IFirmService firmService)
        {
            this._data = data;
            this._firmservice = firmService;
        }

        public async Task<IEnumerable<DocumentListModel>> GetDocumentsByFirmId(int firmId)
            => await this._data.Documents.Select(f =>
                new DocumentListModel()
                {
                    id= f.Id,
                    Description = f.Description
                }).ToListAsync();



        public async Task<DocumentDetailsModel> CreateFirmAsync(CreateDocumentModel model)
        {
            var doc = new DocumentEntityModel()
            {
                Receiver = model.Receiver,
                Description = model.Description,
                Amount = model.Amount,
                Firm = await this._data.Firms.FirstOrDefaultAsync(c => c.Id == model.FirmId)
            };


            await this._data.Documents.AddAsync(doc);
            await this._data.SaveChangesAsync();

            var editedDoc = new DocumentDetailsModel()
            {
                DocumentId = doc.Id,
                Receiver = doc.Receiver,
                Amount = doc.Amount,
                Description = doc.Description,
                FirmId = doc.FirmId,
                FirmName = doc.Firm.Name
            };

            return editedDoc;
        }
          

        public async Task<DocumentDetailsModel> EditDocumentAsync(DocumentDetailsModel detailsModel, int docId)
        {
            var doc = await this._data.Documents.FirstOrDefaultAsync(c => c.Id == docId);

            doc.Receiver = detailsModel.Receiver;
            doc.Amount = detailsModel.Amount;
            doc.Description = detailsModel.Description;
            doc.Firm = await this._data.Firms.FirstOrDefaultAsync(c => c.Id == detailsModel.FirmId);


            var editedDoc = new DocumentDetailsModel()
            {
                DocumentId = doc.Id,
                Receiver = doc.Receiver,
                Amount = doc.Amount,
                Description = doc.Description,
                FirmId = doc.FirmId,
                FirmName = doc.Firm.Name
            };

            await this._data.SaveChangesAsync();

            return editedDoc;
        }
    }
}
