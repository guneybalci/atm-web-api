using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // Generic Repository Oluşturdum. CRUD işlemlerini birden çok yerde kullanabilirim.
    // IEntity'de verebilirdim where T:class,IEntity,new()
    // new lenebilir
    public interface IEntityRepository<T> where T : class
    {
        // Veritabanından istediğim id veya baska şarta göre cekmek icin yaptım Func delagasyonu kullandım.
        T Get(Expression<Func<T, bool>> filter);

        //Hepsini getir
        IList<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
