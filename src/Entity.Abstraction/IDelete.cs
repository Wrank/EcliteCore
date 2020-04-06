using System;

namespace Entity.Abstraction
{
    public interface IDelete: IDelete<Guid>
    {
    }

    public interface IDelete<TPrimaryKeyOfUser>: ISoftDelete
    {
        DateTime? DeletedAt { get; set; }

        TPrimaryKeyOfUser DeletedBy { get; set; }

    }
}
