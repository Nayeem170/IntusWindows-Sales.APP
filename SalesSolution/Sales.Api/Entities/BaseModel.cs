﻿using System.ComponentModel.DataAnnotations;

namespace Sales.Api.Entities
{
    public class IBaseModel
    {
        [Key]
        public Guid UId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}