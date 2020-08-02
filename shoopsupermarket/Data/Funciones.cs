using System.Linq;

namespace shoopsupermarket.Data
{
    public class Funciones
    {
        public int GetProvedorId(string car){
            using(var db = new ApplicationDbContext()){
                var algo = db.Proveedores.ToList();

                int PassId = 0;

                foreach (var item in algo)
                {
                    if (item.NAME == car)
                    {
                        PassId = item.ID;
                    }
                }

                return PassId;
            }
        }

        public int GetCategoriaId(string car){
            using(var db = new ApplicationDbContext()){
                var algo = db.Categorias.ToList();

                int PassId = 0;

                foreach (var item in algo)
                {
                    if (item.CAT == car)
                    {
                        PassId = item.ID;
                    }
                }

                return PassId;
            }
        }
    }
}