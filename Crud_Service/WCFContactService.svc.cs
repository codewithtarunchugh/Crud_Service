using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Crud_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WCFContactService : IWCFContact
    {
        string ConString = "Data Source=.;Initial Catalog=WCFContactDB;Persist Security Info=True;User ID=sa;Password=pokipoki;";
        public int Delete(WCFContact ContactPar)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.DeleteContact", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactPar.ContactID;
                    con.Open();
                    var ID = cmd.ExecuteNonQuery();
                    return ID;
                }
            }
        }

        public int Insert(WCFContact ContactPar)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.InsertContact", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ContactName", SqlDbType.VarChar, 100).Value = ContactPar.ContactName;
                    cmd.Parameters.Add("@ContactAddress", SqlDbType.VarChar, 100).Value = ContactPar.ContactAddress;
                    cmd.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 100).Value = ContactPar.ContactNumber;
                    cmd.Parameters.Add("@ContactDOB", SqlDbType.DateTime).Value = ContactPar.ContactDOB;
                    cmd.Parameters.Add("@ContactIncome", SqlDbType.Money).Value = ContactPar.ContactIncome;
                    con.Open();
                    var ID = cmd.ExecuteScalar();
                    ContactPar.ContactID = Convert.ToInt32(ID.ToString());
                }
            }
            return ContactPar.ContactID;
        }

        public List<WCFContact> SelectAll()
        {
            List<WCFContact> SelectList = new List<WCFContact>();
            using (SqlConnection con = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SelectAllContact", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        if (ds.Tables.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                SelectList.Add(new WCFContact
                                {
                                    ContactAddress = dr["ContactAddress"].ToString(),
                                    ContactDOB = Convert.ToDateTime(dr["ContactDOB"]),
                                    ContactID = Convert.ToInt32(dr["ContactID"]),
                                    ContactIncome = Convert.ToDecimal(dr["ContactIncome"]),
                                    ContactName = Convert.ToString(dr["ContactName"]),
                                    ContactNumber = Convert.ToString(dr["ContactNumber"])
                                });
                            }
                        }
                    }
                }
            }
            return SelectList;
        }

        public int Update(WCFContact ContactPar)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.UpdateContact", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactPar.ContactID;
                    cmd.Parameters.Add("@ContactName", SqlDbType.VarChar, 100).Value = ContactPar.ContactName;
                    cmd.Parameters.Add("@ContactAddress", SqlDbType.VarChar, 100).Value = ContactPar.ContactAddress;
                    cmd.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 100).Value = ContactPar.ContactNumber;
                    cmd.Parameters.Add("@ContactDOB", SqlDbType.DateTime).Value = ContactPar.ContactDOB;
                    cmd.Parameters.Add("@ContactIncome", SqlDbType.Money).Value = ContactPar.ContactIncome;
                    con.Open();
                    var ID = cmd.ExecuteNonQuery();
                    return ID;
                }
            }
        }
    }
}
