using GraduateWorkControl.API.Models.MaterialModels.OutputModels;

namespace GraduateWorkControl.API.Models.WorkModels.OutputModels
{
    public class CommentOutputModel
    {
        public int Id { get; set; }

        public string AuthorsName { get; set; }

        public string? Comment { get; set; }

        public List<MaterialOutputModel> Materials { get; set; }
    }
}
