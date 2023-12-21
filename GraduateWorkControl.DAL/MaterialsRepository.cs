using GraduateWorkControl.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkControl.DAL
{
    public class MaterialsRepository
    {
        private Context _context = Context.MainContext;

        public int AddMaretial(MaterialDto material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
            return material.Id;
        }

        public void ChangeLink(int  id, string link) 
        {
            _context.Materials.Where(m => m.Id == id).FirstOrDefault().Link=link;
            _context.SaveChanges();
        }

        public List<MaterialDto> GetAll(List<int> ids)
        {
            return _context.Materials.Where(m => ids.Contains(m.Id)).ToList();
        }
    }
}
