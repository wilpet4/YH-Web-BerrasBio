using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbSingleton
    {
        private static BerrasBioContext instance;

        public static BerrasBioContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BerrasBioContext();
                }
                return instance;
            }
        }
    }
}
