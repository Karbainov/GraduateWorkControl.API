﻿using AutoMapper;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.WorkModels;
using GraduateWorkControl.Core;
using GraduateWorkControl.DAL;
using GraduateWorkControl.DAL.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                cfg.AddProfile(new MapperStudentProfile());
                cfg.AddProfile(new MapperTeacherProfile());
                cfg.AddProfile(new MapperOptionsProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddTask(TaskCreateModel task)
        {
            var t=_mapper.Map<TaskDto>(task);
            t.Student = _studentRepository.GetStudentById(task.StudentId);
            return _taskRepository.AddTask(t);
        }

        public TaskModel GetTaskById(int id)
        {
            return _mapper.Map<TaskModel>(_taskRepository.GetTaskById(id));
        }

        public List<TaskModel> GetAllTasksByStudentId(int id)
        {
            return _mapper.Map < List<TaskModel> > (_taskRepository.GetAllTasksByStudentId(id));
        }

        public void UpdateTask(TaskUpdateModel task)
        {
            _taskRepository.UpdateTask(_mapper.Map<TaskDto>(task));
        }

        public void DeleteTask(int id)
        {
            _taskRepository.DeleteTask(id);
        }

        public void ChangeTaskState(int id, TaskState taskState)
        {
            _taskRepository.ChangeTaskState(id, taskState);
        }

        public int AddComment(CommentCreateModel comment)
        {
            var c = _mapper.Map<CommentDto>(comment);
            c.Task = _taskRepository.GetTaskById(comment.TaskId);

            if((bool)comment.IsTeacher)
            {
                c.Teacher= _taskRepository.GetTeacherFromTask(comment.TaskId);
            }
            else
            {
                c.Student=_taskRepository.GetStudentFromTask(comment.TaskId);
            }

            return _commentRepository.AddComment(c);
        }

        public void DeleteComment(int id)
        {
            _commentRepository.DeleteComment(id);
        }
    }
}
