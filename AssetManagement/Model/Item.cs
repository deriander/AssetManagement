using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AssetManagement.Base;

namespace AssetManagement.Models
{
    public class Item : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Spesification { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Nullable<DateTimeOffset> UpdateDate { get; set; }
        public Nullable<DateTimeOffset> DeleteDate { get; set; }
    }
}
