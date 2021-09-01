using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UpdateModel
    {
       
        public int NoteId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }

    }
}
