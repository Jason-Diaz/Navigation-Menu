using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Menu
{
    public class Employee
    {
        public string id { get; set; }
        public string department { get; set; }

        public Employee()
        {
            id = "";
            department = "";
        }

        public void readIn(string fileLoc)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(fileLoc);
            id = file.ReadLine();
            department = file.ReadLine();
            file.Close();
        }
    }
}
