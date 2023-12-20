using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.API.Models.StudentModels.OutputModels;
using GraduateWorkControl.API.Models.WorkModels.InputModels;
using GraduateWorkControl.API.Models.WorkModels.OutputModels;
using GraduateWorkControl.BLL;
using GraduateWorkControl.BLL.Models.WorkModels;
using GraduateWorkControl.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkControl.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WorkController : Controller
    {

        Mapper _mapper;
        WorkService _workService;

        public WorkController()
        {
            _workService = new WorkService();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MappingWorkProfile());
            });
            _mapper = new Mapper(config);
        }

        //[Authorize(Roles = "student, teacher")]
        [HttpGet("{studentId}",Name = "GetAllStudentsTasksById")]
        public IActionResult GetAllStudentsTasksById(int studentId)
        {
           return Ok(new List<TaskShortOutputModel>());
        }

        //[Authorize(Roles = "student, teacher")]
        [HttpGet("{studentId}/{taskId}", Name = "GetTaskById")]
        public IActionResult GetTaskById(int taskId)
        {
            return Ok(new TaskOutputModel());
        }

        //[Authorize(Roles = "teacher")]
        [HttpPost("{studentId}", Name = "AddTask")]
        public IActionResult AddTask(int studentId, TaskInputModel task)
        {
            var t = _mapper.Map<TaskCreateModel>(task);
            t.StudentId= studentId;
            return Ok(_workService.AddTask(t));
        }

        //[Authorize(Roles = "teacher")]
        [HttpPut("{studentId}/{taskId}", Name = "UpdateTask")]
        public IActionResult UpdateTask(int taskId, TaskInputModel task)
        {
            return Ok();
        }

        //[Authorize(Roles = "teacher")]
        [HttpDelete("{studentId}/{taskId}", Name = "DeleteTask")]
        public IActionResult DeleteTask(int taskId)
        {
            return Ok();
        }

        //[Authorize(Roles = "teacher")]
        [HttpPut("{studentId}/{taskId}/state", Name = "UpdateTaskState")]
        public IActionResult UpdateTaskState(int taskId, TaskState state)
        {
            return Ok();
        }

        //[Authorize(Roles = "student")]
        [HttpPut("{studentId}/{taskId}/review", Name = "UpdateTaskStateToReview")]
        public IActionResult UpdateTaskStateToReview(int taskId)
        {
            return Ok();
        }

        //[Authorize(Roles = "teacher, student")]
        [HttpPost("{studentId}/{taskId}", Name = "AddComent")]
        public IActionResult AddComent(int taskId, CommentInputModel comment)
        {
            return Ok();
        }

        //[Authorize(Roles = "teacher, student")]
        [HttpDelete("{studentId}/{taskId}/{commentId}", Name = "DeleteComent")]
        public IActionResult DeleteComent(int commentId)
        {
            return Ok();
        }
    }
}
