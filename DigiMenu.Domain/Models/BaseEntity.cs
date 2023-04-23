using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Models
{
    public abstract class BaseEntity
    {
        public virtual Guid id { get; set; }
    }
}
