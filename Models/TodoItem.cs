using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TODOHelperLibrary;

namespace TODOWebApplication.Models
{
    public class TodoItem
    {

        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s]*$", ErrorMessage = "The title contains " +
            "invalid symbols and/or isn't capitalised.")]
        [StringLength(20)]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s]*$", ErrorMessage = "The description contains " +
            "invalid symbols and/or isn't capitalised.")]
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
