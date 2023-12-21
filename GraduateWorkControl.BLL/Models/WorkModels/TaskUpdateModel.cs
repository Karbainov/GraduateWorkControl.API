using GraduateWorkControl.BLL.Models.MaterialModels;
using GraduateWorkControl.BLL.Models.StudentModels;
using GraduateWorkControl.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.WorkModels
{
    public class TaskUpdateModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string? Deadline { get; set; }

        public string? Description { get; set; }

        public List<int>? Materials { get; set; }
    }
}
