﻿using AssetManagement.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Model
{
    [Table("TB_T_Request")]
    public class Request : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Item_Name { get; set; }
        public Boolean Approval_1 { get; set; }
        public Boolean Approval_2 { get; set; }
        public string Specification { get; set; }
        public string Status_Approval { get; set; }
        public DateTimeOffset Request_Date { get; set; }
        public string Brand { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Ram { get; set; }
        public string Display { get; set; }
        public string Storage { get; set; }
        public string Os { get; set; }

        public User User { get; set; }
        [ForeignKey("User")]
        public int User_Id { get; set; }

    }
}
