using DemoMvcCapas.BusinessEntities;
using DemoMvcCapas.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMvcCapas.BusinessLogic
{
    public class CategoriaBL
    {
        CategoriaDA categoriaDA = new CategoriaDA();

        public List<CategoriaBE> GetAll()
        {
            return categoriaDA.GetAll();
        }

        public bool Delete(CategoriaBE entity)
        {
            return categoriaDA.Delete(entity);
        }

        public CategoriaBE Get(int id)
        {
            return categoriaDA.Get(id);
        }

        public bool Insert(CategoriaBE entity)
        {
            return categoriaDA.Insert(entity);
        }

        public bool Update(CategoriaBE entity)
        {
            return categoriaDA.Update(entity);
        }
    }
}
