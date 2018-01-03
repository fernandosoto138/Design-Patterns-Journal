using System.Collections.Generic;
using Newtonsoft.Json;
namespace Adapter_CS_1
{
    class EmployeeAdapter : ThirdPartyAPI, ITarget
    {
        public List<Person> GetEmployeeList()
        {
            return JsonConvert.DeserializeObject<List<Person>>(getEmployesJSON());
        }
    }
    
}

