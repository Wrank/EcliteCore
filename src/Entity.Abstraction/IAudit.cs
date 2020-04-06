using System;

namespace Entity.Abstraction
{
    public interface IAudit : IAudit<Guid>
    {
    }

    public interface IAudit<TPrimaryKeyOfUser> : ICreate<TPrimaryKeyOfUser>, IModify<TPrimaryKeyOfUser>, IDelete<TPrimaryKeyOfUser>
    {
    }
}
