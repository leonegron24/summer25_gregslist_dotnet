namespace gregslist_dotnet.Interfaces;

public interface IRepository<T>
{
  public T Create(T updateData);
  internal List<T> GetAll();
  public T GetById(int id);
  public T Update(T updateData);
  public void Delete(int id);
}