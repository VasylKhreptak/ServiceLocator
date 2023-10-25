public class BaseService : IService
{
    public string Name { get; }

    public BaseService(string name)
    {
        Name = name;
    }
}