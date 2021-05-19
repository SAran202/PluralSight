using InventoryService.Models;
using InventoryService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryServices _services;

        public InventoryController(IInventoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);
            if(inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }
        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>>GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();

            if(inventoryItems.Count == 0)
            {
                return NotFound();
            }
            return inventoryItems;
        }

        [HttpDelete]
        [Route("DelInventoryItems")]
        public ActionResult<InventoryItems> RemoveInventoryItems(InventoryItems items)
        {
            var inventoryItems = _services.RemoveInventoryItems(items);
            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }
    }
}
