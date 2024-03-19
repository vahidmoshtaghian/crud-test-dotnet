using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Core.Domain.Entity.Base;

public class EntityBase
{
    [Key]
    public int Id { get; set; }
}
