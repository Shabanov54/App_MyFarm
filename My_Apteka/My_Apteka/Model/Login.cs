using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Apteka.Model
{
    public class Login
    {
        public List <Person> People { get; set; }
        public Login()
        {
            People = new List<Person>()
            {
            new Person() { LoginName = "it", Password = "Xharyt34=" },
            new Person() { LoginName = "it2", Password = "!QAZxsw2" },
            new Person() { LoginName = "it3", Password = "@WSXcde3" },
            new Person() { LoginName = "it4", Password = "#EDCvfr4" },
        };
        }
        public List<Person>GetPeople()
        {
            return People;
        }
    }
}
