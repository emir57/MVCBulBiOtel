namespace FEntity
{
    public class FluentEntity<T> : FluentEntityBase<T>
        where T : class, new()
    {
        public FluentEntity()
        {
        }

        public FluentEntity(T entity) : base(entity)
        {
        }
    }
}
