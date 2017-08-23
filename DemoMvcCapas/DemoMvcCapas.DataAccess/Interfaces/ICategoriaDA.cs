using DemoMvcCapas.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcCapas.DataAccess.Interfaces
{
    public interface ICategoriaDA
    {
        List<CategoriaBE> GetAll();
        CategoriaBE Get(int id);
        bool Insert(CategoriaBE entity);
        bool Update(CategoriaBE entity);
        bool Delete(CategoriaBE entity);

    }
}
