using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Entidades;
using LogicaNegocio.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService transactionService;

        public TransactionController(TransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            try
            {
                transactionService.AddTransaction(transaction);
                return Ok("Transacción añadida correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al añadir transacción: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                var transactions = transactionService.GetTransactions();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener la lista de transacciones: {ex.Message}");
            }
        }
        [HttpGet("GetTransactionsByDate")]
        public IActionResult GetTransactionsByDate(DateTime date)
        {
            try
            {
                var transactions = transactionService.GetTransactionsByDate(date);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener la lista de transacciones por fecha: {ex.Message}");
            }
        }

    }
}