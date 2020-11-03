using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class DiaryWithSubjectsDAL
    {
        public List<Diaries_Contxts> SelectAll(int sid, int did)
        {
            SqlCommand cmd = new SqlCommand("Select * from diary_subjects where sid=@Sid and did=@Did order by id desc", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Sid", sid);
            cmd.Parameters.AddWithValue("@Did", did);
            return fetchContxt(cmd);
        }

        public Diaries_Contxts SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from diary_subjects where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Diaries_Contxts> temp = fetchContxt(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Diaries_Contxts> fetchContxt(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Diaries_Contxts> diary_contxt = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    diary_contxt = new List<Diaries_Contxts>();
                    while (dr.Read())
                    {
                        Diaries_Contxts dc = new Diaries_Contxts();
                        dc.db_Id = Convert.ToString(dr["id"]);
                        dc.Subject_name = Convert.ToString(dr["subject_name"]);
                        dc.Contxt = Convert.ToString(dr["subject_diary_text"]);
                        dc.Type = Convert.ToString(dr["type"]);
                        dc.Section_id = Convert.ToString(dr["sid"]);
                        dc.Diary_id = Convert.ToString(dr["did"]);
                        diary_contxt.Add(dc);
                    }
                    diary_contxt.TrimExcess();
                }
            }
            return diary_contxt;
        }
    }
}
