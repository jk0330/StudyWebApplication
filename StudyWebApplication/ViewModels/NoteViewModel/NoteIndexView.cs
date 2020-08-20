using System.Collections.Generic;
using System.Data;

namespace StudyWebApplication.ViewModels
{
    public class NoteIndexView
    {
        public List<DataRow> Notes { get; set; }

        public int NoteCount { get; set; }

        public int Page { get; set; }
    }
}
