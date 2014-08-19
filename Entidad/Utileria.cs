using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class Utileria
    {
        public static string Conexion()
        {
            string cnx = "Data Source= JIMMY-PC; database=Clinica; uid=sa; pwd=11294mpjr; connection lifetime=20; connection timeout=50";

            return cnx;
        }
    }
}
