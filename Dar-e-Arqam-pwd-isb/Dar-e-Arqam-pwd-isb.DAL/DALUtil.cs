using System.Data.SqlClient;
using System.Configuration;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class DALUtil
    {
        internal static SqlConnection getConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dar-e-arqam-pwd-isb"].ConnectionString;
            return new SqlConnection(constr);
        }
    }
}
