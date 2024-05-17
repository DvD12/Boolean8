using System.Diagnostics;

namespace BlogMvc.Code
{
    public class CustomLogger1 : ICustomLogger
    {
        public void WriteLog(string message)
        {
            Debug.WriteLine($"LOG 1: {message}");
        }
    }
}
