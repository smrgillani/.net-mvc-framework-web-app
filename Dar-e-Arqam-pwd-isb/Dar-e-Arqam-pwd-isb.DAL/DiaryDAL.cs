using Dar_e_Arqam_pwd_isb.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Dar_e_Arqam_pwd_isb.DAL
{
    public class DiaryDAL
    {
        public List<Diaries> SelectAllDiary()
        {
            SqlCommand cmd = new SqlCommand("Select * from diary order by id desc", DALUtil.getConnection());
            return fetchDiary(cmd);
        }

        public List<Diaries> SelectAllActiveDiary()
        {
            SqlCommand cmd = new SqlCommand("Select * from diary where settings = '2' order by id desc", DALUtil.getConnection());
            return fetchDiary(cmd);
        }

        public List<Diaries> SelectBySearch(string Search_key)
        {
            SqlCommand cmd = new SqlCommand("Select * from diary where diary_date=@Search", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Search", Search_key);
            return fetchDiary(cmd);
        }

        public Diaries SelectById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from diary where Id=@Id", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Diaries> temp = fetchDiary(cmd);
            return (temp != null) ? temp[0] : null;
        }

        public Diaries SelectActiveById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from diary where Id=@Id and settings = '2'", DALUtil.getConnection());
            cmd.Parameters.AddWithValue("@Id", id);
            List<Diaries> temp = fetchDiary(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Diaries> fetchDiary(SqlCommand cmd)
        {
            SqlConnection con = cmd.Connection;
            List<Diaries> diary = null;
            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    diary = new List<Diaries>();
                    while (dr.Read())
                    {
                        Diaries d = new Diaries();
                        d.db_Id = Convert.ToString(dr["id"]);
                        d.Diary_date = Convert.ToString(dr["diary_date"]);
                        d.Settings = Convert.ToString(dr["settings"]);
                        diary.Add(d);
                    }
                    diary.TrimExcess();
                }
            }
            return diary;
        }
    }
}
