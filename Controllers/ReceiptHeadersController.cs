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
    public class ReceiptHeadersController : BaseApiController
    {
        private readonly IReceiptHeaderService _receiptHeaderService;
        public ReceiptHeadersController(IReceiptHeaderService receiptHeaderService)
        {
            _receiptHeaderService = receiptHeaderService;       
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptHeader>>> GetAllReceiptHeaders()
        {
            try
            {
                return Ok(await _receiptHeaderService.GetAllReceiptHeaders());
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not get receipt headers! \n {ex}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> CreateReceiptHeader(ReceiptHeaderDTO receiptHeaderDTO)
        {
            try
            {
                return await _receiptHeaderService.CreateReceiptHeader(receiptHeaderDTO);
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not create receipt header! \n {ex}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateReceiptHeader(ReceiptHeaderDTO receiptHeaderDTO)
        {
            try
            {
                return await _receiptHeaderService.UpdateReceiptHeader(receiptHeaderDTO);
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not update receipt header! \n {ex}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> DeleteReceiptHeader(int id)
        {
            try
            {
                return await _receiptHeaderService.DeleteReceiptHeader(id);
            }
            catch(Exception ex)
            {
                 return BadRequest($"Could not delete receipt header! \n {ex}");
            }
        }
    }
}