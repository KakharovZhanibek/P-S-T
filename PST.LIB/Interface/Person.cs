using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_S_T.Interface
{
    interface IPerson
    {
        string FIO { get; set; }
        int Age { get; set; }
        DateTime DOB { get; set; }

        void Print();
        
    }
}
