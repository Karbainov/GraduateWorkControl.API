using GraduateWorkControl.API.Models.MaterialModels.OutputModels;

namespace GraduateWorkControl.API.Models.WorkModels.InputModels
{
    public class CommentInputModel
    {
        public string? Comment { get; set; }

        public List<int> MaterialsIds { get; set; }
    }
}
