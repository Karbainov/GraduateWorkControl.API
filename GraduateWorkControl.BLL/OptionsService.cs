using GraduateWorkControl.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.BLL
{
    public class OptionsService
    {
        OptionsRepository _optionsRepository;

        public OptionsService()
        {
            _optionsRepository = new OptionsRepository();
        }

        public int AddSubject(string servise)
        {
            return _optionsRepository.AddSubject(servise);
        }

        public int AddFaculty(string faculty)
        {
            return _optionsRepository.AddFacilty(faculty);
        }
    }
}
