using AutoMapper;
using GraduateWorkControl.BLL.Mappings;
using GraduateWorkControl.BLL.Models.OptionsModels;
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
        Mapper _mapper;
        public OptionsService()
        {
            _optionsRepository = new OptionsRepository();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperOptionsProfile());
            });
            _mapper = new Mapper(config);
        }

        public int AddSubject(string servise)
        {
            return _optionsRepository.AddSubject(servise);
        }

        public int AddFaculty(string faculty)
        {
            return _optionsRepository.AddFacilty(faculty);
        }

        public List<SubjectModel> GetAllSubjects()
        {
            return _mapper.Map<List<SubjectModel>>(_optionsRepository.GetAllSubjects());
        }

        public List<FacultyModel> GetAllFacultys()
        {
            return _mapper.Map<List<FacultyModel>>(_optionsRepository.GetAllFacultys());
        }

        public void UpdateSubject(int id, string name)
        {
            _optionsRepository.UpdateSubject(id, name);
        }

        public void UpdateFaculty(int id, string faculty)
        {
            _optionsRepository.UpdateFacuty(id, faculty);
        }
    }
}
