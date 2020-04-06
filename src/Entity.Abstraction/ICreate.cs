using System;

namespace Entity.Abstraction
{
    public interface ICreate : ICreate<Guid>
    {

    }

    public interface ICreate<TPrimaryKeyOfUser>
    {
        DateTime CreatedAt { get; set; }

        TPrimaryKeyOfUser CreatedBy { get; set; }
    }
}
