using AutoMapper;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.WorkModels;
using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL
{
    public class WorkService
    {
        private TeacherRepository _teacherRepository;
        private StudentRepository _studentRepository;
        private TaskRepository _taskRepository;
        private CommentRepository _commentRepository;
        private Mapper _mapper;

        public WorkService()
        {
            _teacherRepository = new TeacherRepository();
            _studentRepository = new StudentRepository();
            _taskRepository = new TaskRepository();
            _commentRepository = new CommentRepository();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperWorkProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddTask(TaskCreateModel task)
        {
            var t=_mapper.Map<TaskDto>(task);
            t.Student = _studentRepository.GetStudentById(task.StudentId);
            return _taskRepository.AddTask(t);
        }



    }
}
