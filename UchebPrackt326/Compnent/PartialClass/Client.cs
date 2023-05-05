using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchebPrackt326.Compnent
{
    public partial class Client
    {
        public string FulName
        {
            get
            {
                return $"{LastName} {FirstName} {Patronymic}";
            }
        }
    }
}
