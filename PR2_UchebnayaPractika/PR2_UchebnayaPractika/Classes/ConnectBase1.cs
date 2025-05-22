using PR2_UchebnayaPractika.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2_UchebnayaPractika.Classes
{
    class ConnectBase1
    {
        public static PR2_Ushebnaya_PracticaEntities entObj;

        static ConnectBase1()
            {
            entObj = new PR2_Ushebnaya_PracticaEntities();
            }
}
    }

