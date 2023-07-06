using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POS_Blagajna_Backend.DTOs.ReceiptItemDTOs;
using POS_Blagajna_Backend.Entities;
using POS_Blagajna_Backend.Interfaces.RepositoryInterfaces;
using POS_Blagajna_Backend.Interfaces.ServiceInterfaces;

namespace POS_Blagajna_Backend.Controllers
{
    public class ReceiptItemsController : BaseApiController
    {
        private readonly IReceiptItemService _receiptItemService;
        public ReceiptItemsController(IReceiptItemService receiptItemService)
        {
            _receiptItemService = receiptItemService;     
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptItem>>> GetAllReceiptItems()
        {
            try
            {
                return Ok(await _receiptItemService.GetAllReceiptItems());
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not get receipt items! \n {ex}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateReceiptItem(ReceiptItemDTO receiptItemDTO)
        {
            try
            {
                return await _receiptItemService.CreateReceiptItem(receiptItemDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not create receipt item! \n {ex}");
            }
        }

        [HttpPost("createMultiple")]
        public async Task<ActionResult<List<ReceiptItem>>> CreateMultipleReceiptItems(List<ReceiptItemDTO> receiptItemDTOs)
        {
            try
            {
                return await _receiptItemService.CreateMultipleReceiptItems(receiptItemDTOs);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not create multiple receipt items! \n {ex}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateReceiptItem(ReceiptItemDTO receiptItemDTO)
        {
            try
            {
                return await _receiptItemService.UpdateReceiptItem(receiptItemDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not update receipt item! \n {ex}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteReceiptItem(int id)
        {
            try
            {
                return await _receiptItemService.DeleteReceiptItem(id);
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not delete receipt item! \n {ex}");
            }
        }
    }
}