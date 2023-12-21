using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.API.Models.StudentModels.OutputModels;
using GraduateWorkControl.API.Models.WorkModels.InputModels;
using GraduateWorkControl.API.Models.WorkModels.OutputModels;
using GraduateWorkControl.BLL;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.WorkModels;
using GraduateWorkControl.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                cfg.AddProfile(new MappingStudentProfile());
                cfg.AddProfile(new MappingTeacherProfile());
                cfg.AddProfile(new MappingOptionsProfile());

            });
            _mapper = new Mapper(config);
        }

        [Authorize(Roles = "student, teacher")]
        [HttpGet("{studentId}",Name = "GetAllStudentsTasksById")]
        public IActionResult GetAllStudentsTasksById(int studentId)
        {
           return Ok(_mapper.Map<List<TaskShortOutputModel>>(_workService.GetAllTasksByStudentId(studentId)));
        }

        [Authorize(Roles = "student, teacher")]
        [HttpGet("{studentId}/{taskId}", Name = "GetTaskById")]
        public IActionResult GetTaskById(int taskId)
        {
            var t=_workService.GetTaskById(taskId);
            var res = _mapper.Map<TaskOutputModel>(t);
            for(int i=0; i<t.Comments.Count(); i++) 
            {
                if (t.Comments[i].Teacher != null)
                {
                    res.Comments[i].AuthorsName = $"{t.Comments[i].Teacher.FirstName} {t.Comments[i].Teacher.LastName}";
                }
                else
                {
                    res.Comments[i].AuthorsName = $"{t.Comments[i].Student.FirstName} {t.Comments[i].Student.LastName}";
                }
            }
            return Ok(res);
        }

        [Authorize(Roles = "teacher")]
        [HttpPost("{studentId}", Name = "AddTask")]
        public IActionResult AddTask(int studentId, TaskInputModel task)
        {
            var t = _mapper.Map<TaskCreateModel>(task);
            t.StudentId= studentId;
            return Ok(_workService.AddTask(t));
        }

        [Authorize(Roles = "teacher")]
        [HttpPut("{studentId}/{taskId}", Name = "UpdateTask")]
        public IActionResult UpdateTask(int taskId, TaskInputModel task)
        {
            var t=_mapper.Map<TaskUpdateModel>(task);
            t.Id= taskId;
            _workService.UpdateTask(t);
            return Ok();
        }

        [Authorize(Roles = "teacher")]
        [HttpDelete("{studentId}/{taskId}", Name = "DeleteTask")]
        public IActionResult DeleteTask(int taskId)
        {
            _workService.DeleteTask(taskId);
            return Ok();
        }

        [Authorize(Roles = "teacher")]
        [HttpPut("{studentId}/{taskId}/state", Name = "UpdateTaskState")]
        public IActionResult UpdateTaskState(int taskId, TaskState state)
        {
            _workService.ChangeTaskState(taskId, state);
            return Ok();
        }

        [Authorize(Roles = "student")]
        [HttpPut("{studentId}/{taskId}/review", Name = "UpdateTaskStateToReview")]
        public IActionResult UpdateTaskStateToReview(int taskId)
        {
            _workService.ChangeTaskState(taskId, TaskState.Review);
            return Ok();
        }

        [Authorize(Roles = "teacher")]
        [HttpPost("{studentId}/{taskId}/teacher", Name = "AddComentByTeacher")]
        public IActionResult AddComentByTeacher(int taskId, CommentInputModel comment)
        {
            var c = _mapper.Map<CommentCreateModel>(comment);
            c.TaskId = taskId; 
            c.IsTeacher= true;
            return Ok(_workService.AddComment(c));
        }

        [Authorize(Roles = "student")]
        [HttpPost("{studentId}/{taskId}", Name = "AddComentByStudent")]
        public IActionResult AddComentByStudent(int taskId, CommentInputModel comment)
        {
            var c = _mapper.Map<CommentCreateModel>(comment);
            c.TaskId = taskId;
            c.IsTeacher = false;
            return Ok(_workService.AddComment(c));
        }

        [Authorize(Roles = "teacher, student")]
        [HttpDelete("{studentId}/{taskId}/{commentId}", Name = "DeleteComent")]
        public IActionResult DeleteComent(int commentId)
        {
            _workService.DeleteComment(commentId);
            return Ok();
        }
    }
}
