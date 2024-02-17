namespace WebAPI.Service
{
    public class FirstService: IFirstService
    {
        public string GetFirst()
        {
            return "My first service";
        }
    }

    public interface IFirstService
    {
        string GetFirst();
    }
}
