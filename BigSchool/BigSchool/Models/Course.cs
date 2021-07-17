namespace BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public bool isLogin = false;
        public bool isShowGoing = false;
        public bool isShowFollow = false;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string LecturerId { get; set; }

        [Required(ErrorMessage = "Place khong duoc trong")]
        [StringLength(255)]
        public string Place { get; set; }

        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "CategoryId khong duoc trong")]
        public int CategoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual Category Category { get; set; }
        public String Name;
        public String LecturerName;

        //add list
        public List<Category> ListCategory = new List<Category>();
    }
}
