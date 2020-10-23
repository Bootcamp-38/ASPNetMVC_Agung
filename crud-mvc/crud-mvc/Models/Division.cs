using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace crud_mvc.Models
{
    [Table("tb_m_Division")]
    public class Division
    {
       
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentID { get; set; }
        public Department DepartmentIDNavigation { get; set; }
    }

    
    //public Division()
    //

    //}
    //public Division(string name, Department department)
    //{
    //    this.Name = name;
    //    this.Department = department;


    //}
}