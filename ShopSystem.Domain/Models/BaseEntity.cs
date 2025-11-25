using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Domain.Models;

public interface IBaseEntity
{
    public int Id { get; set; }
}

public interface IAuditLog
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastEditDate { get; set; }
}