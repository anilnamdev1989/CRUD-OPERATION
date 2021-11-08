using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using BL;
using System.Data;
using System.IO;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BO.Student objStudentBO = new BO.Student();
            DataTable dt = new DataTable();
            BL.Student objStudent = new BL.Student();
            #region GetState
            dt = objStudent.GetState();
            foreach (DataRow dr in dt.Rows)
            {
                objStudentBO.lstState.Add(new SelectListItem
                {
                    Text = Convert.ToString(dr["VC_StateName"]),
                    Value = Convert.ToString(dr["N_StateID"])
                });
            }
            #endregion
            #region GetDepartment
            BL.Department objDepartment = new BL.Department();
            objStudentBO.lstDepartment = objDepartment.GetDepartments();
            #endregion
            return View(objStudentBO);
        }
        [HttpPost]
        public string Index(BO.Student modelStudent)
        {
            if (ModelState.IsValid)
            {
                if (modelStudent.Image_File != null && modelStudent.Resume_File != null)
                {
                    try
                    {
                        string ImageName = Path.GetFileNameWithoutExtension(modelStudent.Image_File.FileName);
                        string ImageExt = Path.GetExtension(modelStudent.Image_File.FileName);
                        Guid objGuid = Guid.NewGuid();
                        ImageName = ImageName + "_" + objGuid.ToString().Replace("-", "") + ImageExt;
                        modelStudent.ProfilePicName = ImageName;
                        //string ServerPath = @"C:\Users\Dell\source\repos\MVC_CRUD\MVC_CRUD\ProfilePicture\";
                        string ServerPath = Server.MapPath("~//ProfilePicture//");
                        modelStudent.ProfilePicPath = ServerPath;
                        string FileNameImage = modelStudent.Image_File.FileName;
                        modelStudent.Image_File.SaveAs(ServerPath + ImageName);

                        string ResumeName = Path.GetFileNameWithoutExtension(modelStudent.Resume_File.FileName);
                        string ResumeExt = Path.GetExtension(modelStudent.Resume_File.FileName);
                        Guid objGuid1 = Guid.NewGuid();
                        ResumeName = ResumeName + "_" + objGuid1.ToString().Replace("-", "") + ResumeExt;
                        modelStudent.ResumeName = ResumeName;
                        // string Serverpath1 = @"C:\Users\Dell\source\repos\MVC_CRUD\MVC_CRUD\ResumeFile\";
                        string Serverpath1 = Server.MapPath("~//ResumeFile//");
                        modelStudent.ResumePath = Serverpath1;
                        string FileNameResume = modelStudent.Resume_File.FileName;
                        modelStudent.Resume_File.SaveAs(Serverpath1 + ResumeName);

                    }
                    catch (Exception ex)
                    {
                        string msg = ex.ToString();
                    }
                }

                modelStudent.Hobbies = string.Join(",", modelStudent.Hoby.Where(x => x.Selected == true).Select(x => x.Text));

                BL.Student obj = new BL.Student();
                obj.InsertStudent(modelStudent);
            }
            

            return " Welcome " + modelStudent.FName + "  " + modelStudent.LName;

        }

        public ActionResult DisplayStudent()
        {
            BL.Student obj = new BL.Student();
            List<BO.Student> lstStudent = new List<BO.Student>();
            lstStudent = obj.GetStudents();
            return View(lstStudent);
        }
        public ActionResult Edit(string id)
        {
            BO.Student objStudentBO = new BO.Student();
            BL.Student obj = new BL.Student();
            objStudentBO = obj.GetStudent(Convert.ToInt32(id));
            DataTable dt = new DataTable();
            #region GetState
            dt = obj.GetState();
            foreach (DataRow dr in dt.Rows)
            {
                objStudentBO.lstState.Add(new SelectListItem
                {
                    Text = Convert.ToString(dr["VC_StateName"]),
                    Value = Convert.ToString(dr["N_StateID"])
                });
            }
            #endregion
            #region GetDepartment
            BL.Department objDepartment = new BL.Department();
            objStudentBO.lstDepartment = objDepartment.GetDepartments();
            #endregion
            foreach(var i in objStudentBO.Hoby)
            {
                if(objStudentBO.Hobbies.Contains(i.Text))
                    {
                    i.Selected = true;
                }
            }
            return View(objStudentBO) ;
        }
        [HttpPost]
        public ActionResult Edit (BO.Student modelStudent, string id)
        {
            if(modelStudent.Image_File!=null)
            {
                try
                {
                    string ImageName = Path.GetFileNameWithoutExtension(modelStudent.Image_File.FileName);
                    string ImageExt = Path.GetExtension(modelStudent.Image_File.FileName);
                    Guid objGuid = Guid.NewGuid();
                    ImageName = ImageName + "_" + objGuid.ToString().Replace("-", "") + ImageExt;
                    modelStudent.ProfilePicName = ImageName;
                    //string ServerPath = @"C:\Users\Dell\source\repos\MVC_CRUD\MVC_CRUD\ProfilePicture\";
                    string ServerPath = Server.MapPath("~//ProfilePicture//");
                    modelStudent.ProfilePicPath = ServerPath;
                    string FileNameImage = modelStudent.Image_File.FileName;
                    modelStudent.Image_File.SaveAs(ServerPath + ImageName);
                }
                catch (Exception ex)
                {

                    string msg = ex.ToString();
                }
            }
            if (modelStudent.Resume_File != null)
            {
                try
                {
                    string ResumeName = Path.GetFileNameWithoutExtension(modelStudent.Resume_File.FileName);
                    string ResumeExt = Path.GetExtension(modelStudent.Resume_File.FileName);
                    Guid objGuid1 = Guid.NewGuid();
                    ResumeName = ResumeName + "_" + objGuid1.ToString().Replace("-", "") + ResumeExt;
                    modelStudent.ResumeName = ResumeName;
                    // string Serverpath1 = @"C:\Users\Dell\source\repos\MVC_CRUD\MVC_CRUD\ResumeFile\";
                    string Serverpath1 = Server.MapPath("~//ResumeFile//");
                    modelStudent.ResumePath = Serverpath1;
                    string FileNameResume = modelStudent.Resume_File.FileName;
                    modelStudent.Resume_File.SaveAs(Serverpath1 + ResumeName);
                }
                catch (Exception ex)
                {

                    string msg=ex.ToString();
                }
            }
            modelStudent.Hobbies = string.Join(",", modelStudent.Hoby.Where(x => x.Selected == true).Select(x => x.Text));

            BL.Student obj = new BL.Student();
            obj.UpdateStudent(modelStudent, Convert.ToInt32(id));
                 
            
            return RedirectToAction("DisplayStudent","Home");
        }
        public ActionResult Delete(string id)
        {
            BL.Student obj = new BL.Student();
            obj.DeleteStudent(Convert.ToInt32(id));
            return RedirectToAction("DisplayStudent","Home",null);
        }

        [HttpGet]
        public JsonResult GetCities(int StateID)
        {
            List<BO.City> lstCity = new List<BO.City>();
            BL.City objCity = new BL.City();
            lstCity = objCity.GetCities(StateID);
            return Json(lstCity, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}