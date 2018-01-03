using System.IO;
namespace Adapter_CS_1
{
    class ThirdPartyAPI
    {
        public static string getEmployesJSON()
        {
            using (StreamReader sr = new StreamReader("workers.json")) 
            {
                return sr.ReadToEnd();
            }
        }
    } 
    
}

