﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.TeacherModels
{
    public class TeacherFullUpdateModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public int FacultyId { get; set; }

        public List<int> SubjectsIds { get; set; }
    }
}