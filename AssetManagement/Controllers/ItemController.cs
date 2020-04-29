using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Base;
using AssetManagement.Models;
using AssetManagement.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BasesController<Item, ItemRepository>
    {
        private readonly ItemRepository _repository;

        public ItemController(ItemRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        [HttpPut("Putitem/{id}")]
        public async Task<ActionResult> Putitem(int id, Item entity)
        {
            var put = await _repository.Get(id);
            if (put == null)
            {
                return BadRequest();
            }
            if (entity.Name != null)
            {
                put.Name = entity.Name;
            }
            if (entity.Spesification != null)
            {
                put.Spesification = entity.Spesification;
            }
            put.UpdateDate = DateTimeOffset.Now;
            await _repository.Put(put);
            return Ok("Update Succesfull");
        }
    }
}