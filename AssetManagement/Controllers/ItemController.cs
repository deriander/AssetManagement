using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Base;
using AssetManagement.Model;
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

        [HttpPost("PostItem")]
        public async Task<ActionResult<Item>> PostItem(Item entity)
        {
            entity.Status = true;
            entity.Create_Date = DateTimeOffset.Now;
            entity.Is_Delete = false;
            await _repository.Post(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);

        }

        [HttpGet("GetItem")]
        public async Task<ActionResult<Item>> GetItem()
        {
            var get = await _repository.GetItem();
            return Ok(new { data = get });
        }

        [HttpPut("PutItem/{id}")]
        public async Task<ActionResult<Item>> PutItem(int id, Item entity)
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
            if (entity.Specification != null)
            {
                put.Specification = entity.Specification;
            }
            put.Update_Date = DateTimeOffset.Now;
            await _repository.Put(put);
            return Ok("Update Succesfully");
        }

        [HttpPut("DeleteItem/{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id, Item entity)
        {
            var delete = await _repository.Get(id);
            //var delete = await _repository.Delete(id);
            if (delete == null)
            {
                return NotFound();
            }
            delete.Delete_Date = DateTimeOffset.Now;
            delete.Is_Delete = true;
            await _repository.Put(delete);
            return Ok("Delete Succesfully");
        }
    }
}