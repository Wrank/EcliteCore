using System;

namespace Entity.Abstraction
{
    public interface IModify : IModify<Guid>
    {
    }

    public interface IModify<TPrimaryKeyOfUser>
    {
        DateTime? ModifiedAt { get; set; }

        TPrimaryKeyOfUser ModifiedBy { get; set; }
    }
}
