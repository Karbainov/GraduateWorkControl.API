namespace GraduateWorkControl.API.Models.WorkModels.OutputModels
{
    public class TaskShortOutputModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public string? Deadline { get; set; }

        public TaskStatus State { get; set; }
    }
}
