using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS_Blagajna_Backend.DTOs.ReceiptHeaderDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Controllers
{
    public class ReceiptsController : BaseApiController
    {
        private readonly IReceiptService _receiptService;
        public ReceiptsController(IReceiptService receiptService)
        {
            _receiptService = receiptService;       
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetAllReceiptHeaders()
        {
            try
            {
                return Ok(await _receiptService.GetAllReceipts());
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not get receipt! \n {ex}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateReceipt(ReceiptDTO receiptDTO)
        {
            try
            {
                return await _receiptService.CreateReceipt(receiptDTO);
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not create receipt! \n {ex}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateReceipt(ReceiptDTO receiptDTO)
        {
            try
            {
                return await _receiptService.UpdateReceipt(receiptDTO);
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not update receipt! \n {ex}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteReceipt(int id)
        {
            try
            {
                return await _receiptService.DeleteReceipt(id);
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not delete receipt! \n {ex}");
            }
        }
    }
}