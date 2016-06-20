using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SectionDemo.ViewModels
{
    public class ListModelsVM
    {
        public List<Properties> EmployeeSettings { get; set; }
        public List<Properties> NameSettings { get; set; }
    }
    public class Properties
    {
        public int SectionNumber { get; set; }
        public string SectionName { get; set; }
        public string DictSectionName { get; set; }
        public int? SortOrder { get; set; }
        public string Description { get; set; }
        public bool Display { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}