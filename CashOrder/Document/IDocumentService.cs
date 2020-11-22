namespace CashOrder.Document
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IDocumentService
    {
        Task<IEnumerable<DocumentListModel>> GetDocumentsByFirmId(int firmId);

        Task<DocumentDetailsModel> CreateFirmAsync(CreateDocumentModel model);

        Task<DocumentDetailsModel> EditDocumentAsync(DocumentDetailsModel detailsModel, int docId);

    }
}
