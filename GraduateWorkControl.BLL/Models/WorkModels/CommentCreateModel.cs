using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.WorkModels
{
    public class CommentCreateModel
    {
        public bool? IsTeacher { get; set; }

        public int TaskId {  get; set; }

        public string? Comment { get; set; }

        public List<int>? MaterialsIds { get; set; }
    }
}
