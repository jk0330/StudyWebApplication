using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWebApplication.ViewModels
{
    public class NoteIndexCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }
    }
}
