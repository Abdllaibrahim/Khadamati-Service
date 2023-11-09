using Khadamati.BLL.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khadamati.BLL.Managers.Category;

public interface ICategoryManger
{
    List<CategoryReadDTO> GetAll();

    int Add(CategoryAddDTO category);

    bool Remove(int id);

    bool Update(CategoryUpdateDTO category);
    CategoryReadDTO Getbyid(int id);
}
