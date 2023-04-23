using DigiMenu.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Interfaces
{
    public interface IDigiMenuService<TEntity> where TEntity : class
    {
        // TOutputModel GetById<TOutputModel>(Guid id) where TOutputModel : class;
       // IEnumerable<TOutputModel> GetEstabelecimentos<TOutputModel>() where TOutputModel : class;

    }
}
