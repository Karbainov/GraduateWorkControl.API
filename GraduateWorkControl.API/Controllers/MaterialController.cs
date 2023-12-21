using AutoMapper;
using GraduateWorkControl.API.Mappings;
using GraduateWorkControl.BLL;
using GraduateWorkControl.BLL.Models.MaterialModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkControl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : Controller
    {
        Mapper _mapper;
        WorkService _workService;

        public MaterialController()
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

        [HttpPost(Name = "Upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }

            MaterialModel material = new MaterialModel()
            {
                Name = file.Name,
                Link = ""
            };
            material.Id = _workService.AddMaterial(material);



            string filePath = Path.Combine("uploads", $"m{material.Id}");
            Directory.CreateDirectory(filePath);
            
            filePath = Path.Combine(filePath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            material.Link = filePath;

            _workService.ChangeLink(material.Id, material.Link);

            return Ok(material);
        }
    }
}
