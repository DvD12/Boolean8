using System.Diagnostics;

namespace BlogMvc.Code
{
    public class CustomLogger2 : ICustomLogger
    {
        public void WriteLog(string message)
        {
            Debug.WriteLine($"LOG 2: {message}");
        }
    }
}
