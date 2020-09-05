using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TODOHelperLibrary;
using TODOWebApplication.Interfaces;

namespace TODOWebApplication.Models
{
    public class TodoItem
    {

        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s\.,'""\*]*$", ErrorMessage = "The title contains invalid symbols")]
        [StringLength(20)]
        public string Title { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s/.,'""\*]*$", ErrorMessage = "The title contains invalid symbols")]
        [StringLength(200)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Added")]
        public DateTime AddedDate { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Expires")]
        public DateTime ExpirationDate { get; set; }
        
        [Required]
        [Column(TypeName = "tinyint")]
        public ItemStatus Status { get; set; }
    }
}
