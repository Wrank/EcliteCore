namespace Entity.Abstraction
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
