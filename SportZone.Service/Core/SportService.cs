using Microsoft.EntityFrameworkCore;
using SportZone.Service.Data;
using SportZone.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportZone.Service.Core
{
    public class SportService
    {
        private readonly AppDbContext _db;
        public SportService(AppDbContext db)
        {
            _db = db;
        }
        public List<SportDTO> GetAll()
        {
            var models = _db.Sports.Include(p=>p.Category).ToList();
            var dtoList = new List<SportDTO>();
            foreach (var model in models)
            {
                var dto = new SportDTO()
                {
                    Id = model.Id,
                    CategoryId = model.CategoryId,
                    Name = model.Name,
                    Description = model.Description,
                    CategoryName = model.Category.Name,
                };
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public SportDTO GetEditViewModel(int id)
        {
            var model = _db.Sports.First(p => p.Id == id);
            var dto = new SportDTO()
            {
                Id = id,
                CategoryId = model.CategoryId,
                Name = model.Name,
                Description = model.Description,
            };
            dto.CategoryList = _db.Categories.ToList();
            return dto;
        }
        public SportDTO GetCreateViewModel()
        {
            var dto = new SportDTO();
            dto.CategoryList = _db.Categories.ToList();
            return dto;
        }
        public void Save(SportDTO dto)
        {
            if (dto.Id == 0)
            {
                var model = new Sport
                {
                    CategoryId = dto.CategoryId,
                    Name = dto.Name,
                    Description = dto.Description,
                };
                _db.Sports.Add(model);
            }
            else
            {
                var model = _db.Sports.Find(dto.Id);
                model.Name = dto.Name;
                model.Description = dto.Description;
                model.CategoryId = dto.CategoryId;
                _db.Sports.Update(model);
            }

            _db.SaveChanges();
        }
        public void Delete(int Id)
        {
            var model = _db.Sports.Find(Id);
            _db.Sports.Remove(model);
            _db.SaveChanges();
        }
    }
}
