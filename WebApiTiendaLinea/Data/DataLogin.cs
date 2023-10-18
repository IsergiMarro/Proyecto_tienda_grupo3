using WebApiTiendaLinea.Models;

namespace WebApiTiendaLinea.Data
{
    public class DataLogin
    {
        public static bool login(clsLogin log)
        {
            bool result = false;
            if (log.user=="luis"&&log.password=="umg123") { 
            result = true;
            }
            return result;
        }
    }
}
