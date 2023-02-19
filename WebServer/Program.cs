using WebServer;

internal class Program
{
    public static void Main(string[] args)
    {
        HttpServer server = new HttpServer();
        Console.WriteLine("Starting server....");
        server.Start();
        Console.WriteLine("Shutting down.....");
    }
}