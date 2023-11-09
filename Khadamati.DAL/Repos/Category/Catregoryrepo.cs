using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khadamati.DAL.Repos;

public class Catregoryrepo:ICategoryrepo
{
    KhadamatiContext _context;

    public Catregoryrepo(KhadamatiContext context)
    {
         _context = context;
    }

    public void Add(Category category)
    {
        _context.Set<Category>().Add(category);
    }

    public List<Category> GetAll()
    {
        return _context.Set<Category>().ToList();
    }

    public Category GetbyID(int id)
    {
        return _context.Set<Category>().Where(d => d.Id == id).FirstOrDefault();
    }

    public void Remove(Category category)
    {
        if (category != null)
        {
            _context.Set<Category>().Remove(category);
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Update(Category category)
    {
       
    }
}
