namespace CashOrder.Firms
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [ApiController]
    [Route("[controller]")]
    public class FirmController : ControllerBase
    {
        private readonly IFirmService _firmService;

        public FirmController(IFirmService firmService)
        {
            this._firmService = firmService;
        }

        [HttpGet]
        public async Task<IEnumerable<FirmListModel>> Get()
            => await this._firmService.GetFirmsAsync();

        
        [HttpPut]
        public async Task<FirmDetailsModel> Edit(FirmDetailsModel detailsModel)
        {
            return await this._firmService.EditFirmAsync(detailsModel, detailsModel.Id);
        }


        [HttpPost]public async Task<IActionResult> Create(CreateFirmModel model)
        {
            var result = await this._firmService.CreateFirmAsync(model);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

    
        
    }
}
