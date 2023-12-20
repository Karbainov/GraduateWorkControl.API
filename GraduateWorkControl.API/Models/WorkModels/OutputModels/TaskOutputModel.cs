using GraduateWorkControl.API.Models.MaterialModels.OutputModels;
using GraduateWorkControl.Core;

namespace GraduateWorkControl.API.Models.WorkModels.OutputModels
{
    public class TaskOutputModel
    {
        public int Id { get; set; }

        public int Number {  get; set; }

        public string Name { get; set; }

        public string? Deadline { get; set; }

        public string? Description { get; set; }

        public List<MaterialOutputModel> Materials { get; set; }

        public TaskState State { get; set; }

        public List<CommentOutputModel> Comments { get; set; }
    }
}
