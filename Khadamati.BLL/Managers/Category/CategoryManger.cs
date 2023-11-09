using Azure.Core;
using Khadamati.BLL.DTO.Category;
using Khadamati.BLL.Managers;
using Khadamati.BLL.Managers.Category;

using Khadamati.DAL;
using Khadamati.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khadamati.BLL;

public class CategoryManger : ICategoryManger
{
    
    IUnitofWork _repo;
    public CategoryManger(IUnitofWork repo)
    {
        _repo = repo;
    }
    public int Add(CategoryAddDTO CategoryFromRueqest)
    {
        Category category = new Category()
        {
            Name = CategoryFromRueqest.Name
            
        };
        _repo.CategoryRepo.Add(category);
        _repo.SaveChanges();
        return category.Id;
    }

    public List<CategoryReadDTO> GetAll()
    {
        List<Category> categories = _repo.CategoryRepo.GetAll();
        return categories.Select(d => new CategoryReadDTO
        {
            Id = d.Id,
            Name = d.Name

        }).ToList();
    }

    public CategoryReadDTO Getbyid(int id)
    {
        Category d = _repo.CategoryRepo.GetbyID(id);
        return new CategoryReadDTO
        {
            Id = d.Id,
            Name = d.Name

        };
    }
    public bool Remove(int id)
    {
        Category? category = _repo.CategoryRepo.GetbyID(id);
        if (category == null) return false;

        _repo.CategoryRepo.Remove(category);
        _repo.SaveChanges();
        return true;
    }

   

    public bool Update(CategoryUpdateDTO CategoryRequested)
    {
        Category? category = _repo.CategoryRepo.GetbyID(CategoryRequested.Id);
        if (category == null) return false;
        category.Name = CategoryRequested.Name;
        category.Id = CategoryRequested.Id;
        _repo.CategoryRepo.Update(category);
        _repo.SaveChanges();
        return true;
    }
}
