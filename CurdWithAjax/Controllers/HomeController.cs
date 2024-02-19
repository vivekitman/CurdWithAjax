using CurdWithAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CurdWithAjax.Controllers
{
    public class HomeController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public void insertData(StudentClass ss)
        {
             
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SpEmpinsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", ss.Name);
            cmd.Parameters.AddWithValue("@Mobile", ss.Mobile);
            cmd.Parameters.AddWithValue("@Email", ss.Email);
            cmd.Parameters.AddWithValue("@DOB", ss.DOB);

            con.Open();
            int a =cmd.ExecuteNonQuery();
            
            con.Close();
        }

        public ActionResult Display()
        {
            return View();
        }

        public List<StudentClass> GetEmpData()
        {
            List<StudentClass> lst = new List<StudentClass>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SpEmpShow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

           SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                lst.Add(new StudentClass
                {
                    id = int.Parse(dr["id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    Email = dr["Email"].ToString(),
                    DOB = dr["DOB"].ToString(),


                }) ; 
            }
            con.Close();
            return lst;
        }
        public JsonResult GetAllData()
        {

            return Json(GetEmpData(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteData(int id)
        {

            ////try
            ////{
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SpEmpDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id  );

            con.Open();
            int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {

                    return Json("Your Data Delete", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Data Not Delete", JsonRequestBehavior.AllowGet);
                }

             con.Close();
            //    return Json("Your Data Delete", JsonRequestBehavior.AllowGet);

            //}
            //catch (Exception )
            //{

            //    return Json("Data Not Delete", JsonRequestBehavior.AllowGet);
            //}

           
        }

        public List<StudentClass> GetEmpSingalData(int id)
        {
            List<StudentClass> lst = new List<StudentClass>();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SPEmpSingleData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lst.Add(new StudentClass
                {
                    id = int.Parse(dr["id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Mobile = dr["Mobile"].ToString(),
                    Email = dr["Email"].ToString(),
                    DOB = dr["DOB"].ToString(),


                });
            }
            con.Close();
            return lst;
        }

        public JsonResult GetSingalData(int id)
        {

            return Json(GetEmpSingalData(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult upData(int id , string name ,string mobile , string email, string dob)
        {

            ////try
            ////{
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SpEmpUpdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Mobile", mobile);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@DOB", dob);


            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {

                return Json("Your Data Update", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Data Not Update", JsonRequestBehavior.AllowGet);
            }

            con.Close();
            //    return Json("Your Data Delete", JsonRequestBehavior.AllowGet);

            //}
            //catch (Exception )
            //{

            //    return Json("Data Not Delete", JsonRequestBehavior.AllowGet);
            //}


        }

    }
}