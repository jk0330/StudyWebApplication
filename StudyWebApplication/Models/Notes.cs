using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudyWebApplication.Models
{
    public class Notes
    {
        [Required]
        public string No { get; set; }

        [Required]
        public DateTime Create_DATE { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

    }
}
