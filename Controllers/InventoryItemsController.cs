using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Context;
using Inventory.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    [EnableCors("mypolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly AppDbContext context;

        public InventoryItemsController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<InventoryItemsController>
        [HttpGet]
        public IEnumerable<InventoryItems> Get()
        {
            return context.InventoryItems.ToList();
        }

        // GET api/<InventoryItemsController>/5
        [HttpGet("{id}")]
        public InventoryItems Get(int id)
        {
            var producto = context.InventoryItems.FirstOrDefault(p => p.IdItem == id);
            return producto;
        }

        // POST api/<InventoryItemsController>
        [HttpPost]
        public ActionResult Post([FromBody] InventoryItems inventoryItems)
        {
            try
            {
                context.InventoryItems.Add(inventoryItems);
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        // PUT api/<InventoryItemsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] InventoryItems inventoryItems)
        {
            if (inventoryItems.IdItem == id)
            {
                context.Entry(inventoryItems).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<InventoryItemsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var inventoryItems = context.InventoryItems.FirstOrDefault(p => p.IdItem == id);
            if (inventoryItems != null)
            {
                context.InventoryItems.Remove(inventoryItems);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
