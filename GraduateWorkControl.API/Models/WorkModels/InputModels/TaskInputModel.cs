using GraduateWorkControl.API.Models.MaterialModels.OutputModels;
using GraduateWorkControl.API.Models.WorkModels.OutputModels;

namespace GraduateWorkControl.API.Models.WorkModels.InputModels
{
    public class TaskInputModel
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public string? Deadline { get; set; }

        public string? Description { get; set; }

        public List<int>? MaterialsIds { get; set; }

    }
}
