using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication3.Models
{
    [MetadataType(typeof(Blog_Validation))]
    public partial class Blog
    {
    }

    public class Blog_Validation
    {
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(250, ErrorMessage = "UserName may not be longer than 250 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Text is required")]
        [StringLength(250, ErrorMessage = "Text may not be longer than 250 characters")]
        public string BlogText { get; set; }

        [Required(ErrorMessage = "Mood is required")]
        [StringLength(50, ErrorMessage = "Mood may not be longer than 50 characters")]
        public string Mood { get; set; }
    }
}