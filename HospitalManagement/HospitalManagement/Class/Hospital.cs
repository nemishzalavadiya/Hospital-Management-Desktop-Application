using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Class
{
    interface iHospital
    {
        string insert();
        string delete(string id);
        string update(string a, string b, string c, string d, string e, string f);

        object show(); 
    }
}
