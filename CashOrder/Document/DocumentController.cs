namespace CashOrder.Document
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;


    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentListModel>> Get(int firmID)
            => await this._documentService.GetDocumentsByFirmId(firmID);



        [HttpPut]
        public async Task<DocumentDetailsModel> Edit(DocumentDetailsModel model,int docId)
            => await this._documentService.EditDocumentAsync(model, docId);


        [HttpPost]
        public async Task<DocumentDetailsModel> Create(CreateDocumentModel model)
            => await this._documentService.CreateFirmAsync(model);
    }
}
