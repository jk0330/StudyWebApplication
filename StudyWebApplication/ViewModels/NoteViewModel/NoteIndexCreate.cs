using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWebApplication.ViewModels
{
    public class NoteIndexCreate
    {
        public string Title { get; set; }

        public string Contents { get; set; }

        public string UserName { get; set; }
    }
}
