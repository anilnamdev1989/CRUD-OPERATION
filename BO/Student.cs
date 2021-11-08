using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BO
{
    public class Student
    {
        public Student()
        {
            Hoby.Add(new SelectListItem { Text = "Reading", Value = "Reading" });
            Hoby.Add(new SelectListItem { Text = "Swiming", Value = "Swiming" });
            Hoby.Add(new SelectListItem { Text = "Singing", Value = "Singing" });
            Hoby.Add(new SelectListItem { Text = "Playing", Value = "Playing" });
        }
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Department is Required")]
        [DisplayName("Department")]
        public int DepartmentID { get; set; }
        [DisplayName("First")]
        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression(pattern: @"^[a-zA-Z ]*$", ErrorMessage = "Only alphabets allowed")]

        public string FName { get; set; }
        [DisplayName("Last")]
        [Required(ErrorMessage = "Last Name is Required")]
        [RegularExpression(pattern: @"^[a-zA-Z ]*$", ErrorMessage = "Only alphabets allowed")]

        public string LName { get; set; }
        [Required(ErrorMessage = "DOB  is Required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Email  is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number  is Required")]
        [RegularExpression("[1-9]{1}[0-9]{9}",ErrorMessage ="Invalid Input")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City Name is Required")]
        public int CityID { get; set; }
        [Required(ErrorMessage = "State Name is Required")]

        public int StateID { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }
        [DisplayName("State")]
        public string StateName { get; set; }
        [DisplayName("Department")]

        public string DepName { get; set; }
        [DisplayName("University")]
        [Required (ErrorMessage ="University Name is Required")]
        [RegularExpression(pattern: @"^[a-zA-Z ]*$",ErrorMessage ="Only alphabets allowed")]
        public string UniversityName { get; set; }
        public string Hobbies { get; set; }
        public string ProfilePicPath { get; set; }
        public string ResumePath { get; set; }
        [DisplayName("P_Picture")]
        public string ProfilePicName { get; set; }
        [DisplayName("Resume")]
        public string ResumeName { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.jpeg)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase Image_File { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$", ErrorMessage = "Only Valid files allowed.")]

        public HttpPostedFileBase Resume_File { get; set; }

        public List<SelectListItem> lstState { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> lstDepartment { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Hoby { get; set; } = new List<SelectListItem>();
    }
}
