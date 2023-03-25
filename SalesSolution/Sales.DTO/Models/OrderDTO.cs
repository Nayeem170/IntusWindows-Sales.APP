﻿using System.ComponentModel.DataAnnotations;

namespace Sales.DTO.Models
{

    public class OrderDTO : BaseDTO
    {
        public OrderDTO()
        {
            UId = Guid.NewGuid();
        }

        [Required(ErrorMessage = "Please enter an order name.")]
        [MaxLength(30, ErrorMessage = "Please enter an order name with a maximum of 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an order state.")]
        [MaxLength(2, ErrorMessage = "Please enter an order state with a maximum of 2 characters.")]
        [RegularExpression(@"^[A-Z]*$", ErrorMessage = "Please use only uppercase letters for the order state field.")]
        public string State { get; set; }
        public IEnumerable<WindowDTO> Windows { get; set; } = new List<WindowDTO>();
    }
}
