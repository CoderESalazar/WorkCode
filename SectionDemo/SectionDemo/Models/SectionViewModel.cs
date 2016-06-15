using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SectionDemo.Models
{
    public class ListModels
    {
        public List<SectionViewModel> EmployeeSettings { get; set; }
        public List<SectionViewModel> NameSettings { get; set; }
    }


    public class SectionViewModel
    {
        public int SectionNumber { get; set; }
        public string SectionName { get; set; }
        public string DictSectionName { get; set; }
        public int? SortOrder { get; set; }
        public string Description { get; set; }
        public bool Display { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public List<SectionViewModel> EmployeeSettings { get; set; }
        //public List<SectionViewModel> NameSettings { get; set; }
    }


}