using ServerPart;

class Program
{
    
    static Thread thread;
    private static void Main(string[] args)
    {
    
        try
        {
            thread = new Thread(new ThreadStart(Server.Start));
            thread.Start();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
