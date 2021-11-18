using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagment.Models
{
    public class StudentMetadata
    {
        [StringLength(50)]
        [Display(Name = "Estudiante Nombre")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Fecha de Inscripción")]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
    }

    [MetadataType(typeof(StudentMetadata))]
    public partial class Student{}
}