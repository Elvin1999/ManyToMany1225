﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany1225.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public Student()
        {
            Courses=new List<Course>();
        }
    }
}
