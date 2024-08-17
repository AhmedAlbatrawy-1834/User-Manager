using System.Drawing;
using Classes;
namespace UserProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SystemClass obj = SystemClass.GetInstance();
            obj.Run();
        }
    }

    
}
