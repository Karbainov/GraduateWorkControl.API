using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL
{
    public class OptionsRepository
    {
        private Context _context;

        public OptionsRepository()
        {
            _context = new Context();
        }

        public int AddSubject(string subject)
        {
            SubjectDto subjectDto = new SubjectDto() { Name = subject };
            _context.Subjects.Add(subjectDto);
            _context.SaveChanges();

            return subjectDto.Id;
        }

        public int AddFacilty(string faculty)
        {
            FacultyDto facultyDto = new FacultyDto() { Name = faculty };
            _context.Facultys.Add(facultyDto);
            _context.SaveChanges();

            return facultyDto.Id;
        }

        public SubjectDto GetSubjectById(int id)
        {
            return _context.Subjects.Where(s => s.Id == id).Single();
        }

        public FacultyDto GetFacultyById(int id)
        {
                return _context.Facultys.Where(s => s.Id == id).Single();
        }

        public List<SubjectDto> GetSubjectById(List<int> ids)
        {            
            return _context.Subjects.Where(s => ids.Contains(s.Id)).ToList();  
        }

        public List<SubjectDto> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }

        public List<FacultyDto> GetAllFacultys()
        {
            return _context.Facultys.ToList();
        }

        public void UpdateSubject(int id, string name)
        {
            _context.Subjects.Where(s=>s.Id==id).Single().Name = name;
            _context.SaveChanges();
        }

        public void UpdateFacuty(int id, string name)
        {
            _context.Facultys.Where(s => s.Id == id).Single().Name = name;
            _context.SaveChanges();
        }
    }
}
