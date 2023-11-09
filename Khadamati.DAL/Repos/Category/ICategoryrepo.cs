using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khadamati.DAL.Repos;

public interface ICategoryrepo
{
    List<Category> GetAll();

    Category GetbyID(int id);   

    void Add(Category category);

    void Remove(Category category);

    int SaveChanges();

    void Update(Category category);

}
