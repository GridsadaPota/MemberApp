using Member_App.Interface;
using Member_App.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace Member_App.Services
{
    public class MemberService : IMemberService
    {
        public bool AddMember(MemberModel memberModel)
        {
            try 
            {

                string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                string sql = "insert into Member (Member_Code,Member_Name,Member_Tel,Member_LT) ";
                sql += "values ('"+memberModel.Member_Code+ "','"+memberModel.Member_Name+ "','"+memberModel.Member_Tel+"',"+memberModel.Member_LT+")";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();  
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                //throw;
                return false;
            }
             
        }

        public bool DeleteMember(int id)
        {
            try 
            {
                string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                string sql = "Delete from Member where Member_ID = "+id+" ";                
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public bool EditMember(MemberModel memberModel)
        {
            try 
            {
               string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                string sql = "Update Member set Member_Code = '" + memberModel.Member_Code + "' ";
                sql += " ,Member_Name = '" + memberModel.Member_Name + "' ";
                sql += " ,Modifire_Date=Getdate() ";
                sql += " ,Member_Tel = '"+memberModel.Member_Tel+"'";
                sql += " ,Member_LT = " + memberModel.Member_LT + "";
                sql += " where Member_ID = "+memberModel.Member_ID+" ";
            
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();  
                conn.Close();
                return true;        
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public IEnumerable<MemberModel> GetAll()
        {
            try
            {
                List<MemberModel> list = new List<MemberModel>();            
                string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                string sql = "select Member_ID,Member_Code,Member_Name,Member_Tel,Member_LT from Member";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];
                for (int i = 0; i<dt.Rows.Count; i++)
                {
                    MemberModel model = new MemberModel()
                    {
                        Member_ID = Convert.ToInt32(dt.Rows[i]["Member_ID"].ToString()),
                        Member_Code = dt.Rows[i]["Member_Code"].ToString(),
                        Member_Name = dt.Rows[i]["Member_Name"].ToString(),
                        Member_Tel = dt.Rows[i]["Member_Tel"].ToString(),
                        Member_LT = string.IsNullOrEmpty(dt.Rows[i]["Member_LT"].ToString()) ? 0: Convert.ToInt32(dt.Rows[i]["Member_LT"].ToString()) 

                    };
                    //add Model to list
                    list.Add(model);
                }



                //return data 
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
           

        }

        public MemberModel GetMemberByid(int id)
        {
            try
            {                            
                string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(connectionstring);
                string sql = "select Member_ID,Member_Code,Member_Name,Member_Tel,Member_LT from Member where Member_ID = "+id+" ";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];

                //Add Data to Member model
                MemberModel model = null;
                if (dt.Rows.Count > 0) 
                {
                    model = new MemberModel()
                    {
                        Member_ID = Convert.ToInt32(dt.Rows[0]["Member_ID"].ToString()),
                        Member_Code = dt.Rows[0]["Member_Code"].ToString(),
                        Member_Name = dt.Rows[0]["Member_Name"].ToString(),
                        Member_Tel = dt.Rows[0]["Member_Tel"].ToString(),
                        Member_LT = string.IsNullOrEmpty(dt.Rows[0]["Member_LT"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[0]["Member_LT"].ToString())

                    };
                }              
                //return data 
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
