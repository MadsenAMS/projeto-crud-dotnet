namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
         Dictionary<Guid, T> Dictionary();
         T ReturnByID(Guid id);
         void Insert(T entity);
         void Delete(Guid id);
         void Update(Guid id, T entity);
         Guid NextId();

    }
}