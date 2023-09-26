using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using LogicaNegocio;

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly TransactionService TransactionService;

        public TransactionController(TransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        // POST: api/Transactions
        [HttpPost]
        public IActionResult CreateTransaction([FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            _transactionService.CreateTransaction(transaction);

            return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }

        // GET: api/Transactions
        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> GetTransactions()
        {
            var transactions = _transactionService.GetTransactions();
            return Ok(transactions);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransaction(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // GET: api/Transactions?startDate=2023-01-01&endDate=2023-12-31
        [HttpGet("filter")]
        public ActionResult<IEnumerable<Transaction>> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            var transactions = _transactionService.GetTransactionsByDateRange(startDate, endDate);

            if (!transactions.Any())
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        //// GET: TransactionController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: TransactionController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TransactionController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TransactionController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TransactionController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TransactionController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TransactionController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TransactionController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
