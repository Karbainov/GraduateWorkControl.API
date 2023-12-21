﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL.Models.MaterialModels
{
    public class MaterialModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }
    }
}
