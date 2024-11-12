using GlobalQueryFilter.Domain.Contracts.Commands;
using GlobalQueryFilter.Domain.Contracts.Queries;
using GlobalQueryFilter.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalQueryFilter.Api.Controllers
{
    [ApiController]
    [Route("invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IAddInvoiceCommand _command;
        private readonly IGetInvoiceByOwnerQuery _queryByOwner;
        private readonly IGetAllInvoicesQuery _queryAll;

        public InvoiceController(IAddInvoiceCommand command, IGetInvoiceByOwnerQuery queryByOwner, IGetAllInvoicesQuery queryAll)
        {
            _command = command;
            _queryByOwner = queryByOwner;
            _queryAll = queryAll;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddInvoiceCommandDto body, CancellationToken cancellationToken)
        {
            await _command.ExecuteAsync(body, cancellationToken);

            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllInvoicesQueryDto query, CancellationToken cancellationToken)
        {
            var result = await _queryAll.ExecuteAsync(query, cancellationToken);

            return Ok(result);
        }

        [HttpGet("/invoices:by-owner")]
        public async Task<IActionResult> GetByOwner([FromQuery] GetInvoiceByOwnerQueryDto query, CancellationToken cancellationToken)
        {
            var result = await _queryByOwner.ExecuteAsync(query, cancellationToken);

            return Ok(result);
        }
    }
}
