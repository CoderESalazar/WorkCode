using SectionDemo.Data;
using SectionDemo.Models;
using SectionDemo.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SectionDemo.ViewModels;

namespace SectionDemo.Controllers
{
    public class SectionController : Controller
    {

        public static Dictionary<string, int> sectionDict = new Dictionary<string, int>
        {
            {"Employees", 500 },
            {"Names", 600}

        };
        EdsCompanyEntities dbContent = new EdsCompanyEntities();
        // GET: Section
        public ActionResult LoadLists()
        {
            ListModelsVM employees = new ListModelsVM();

            //employees.EmployeeSettings = (from myTable in dbContent.Employees
            //                              select new Properties
            //                              {
            //                                  FirstName = myTable.FirstName,
            //                                  LastName = myTable.LastName

            //                              }).ToList();
            employees.EmployeeSettings = GetEmployeeSettings(500).ToList();
           

            employees.NameSettings = (from thisTable in dbContent.Section_Table
                                      select new Properties
                                      {
                                          SectionNumber = thisTable.section_num,
                                          SectionName = thisTable.section_name

                                      }).ToList();


            return View(employees);
        }
        private IEnumerable<Properties> GetEmployeeSettings(int SectionNumber)
        {
            //var employees = new ListModelsVM();

            var EmployeeSettings = (from myTable in dbContent.Employees
                                    select new Properties
                                    {
                                        FirstName = myTable.FirstName,
                                        LastName = myTable.LastName

                                    }).ToList();

            return EmployeeSettings;
         }
        [HttpPost]
        public ActionResult LoadLists(ListModelsVM _objItems)
        {


          return Redirect("");
        }

        public ActionResult SortedGrid()
        {

             var getSortedGrid = (from dict in sectionDict
                                 join myTable in dbContent.Section_Table on dict.Value equals myTable.section_num
                                 select new SectionViewModel
                                 {
                                     SectionName = myTable.section_name,
                                     SectionNumber = dict.Value,
                                     DictSectionName = dict.Key,
                                     SortOrder = myTable.sort_order,
                                     Description = myTable.description,
                                     Display = myTable.display_id

                                 }).ToList();

   
            return View(getSortedGrid);
        }

        //public ActionResult Index()
        //{
        //    //question is whether we can grab enums and use them in the LINQ statement

        //    //var getSections

        //    //we need to be able to loop through this my enums. The dictionary idea
        //    //seems like a smart idea. 

        //    //Have to stop for the day. I need to pick Zhenya but I am starting to see the 
        //    //crux of the problem.            

        //    var model = new SectionViewModel();

        //    foreach (KeyValuePair<string, int> kvp in sectionDict)
        //    {

        //        if (kvp.Key == "EmployeeSetting")
        //        {

        //            ViewBag.Employee = dbContent.Section_Table.Where(t => t.open_label.Contains(kvp.Key)).Select(z => z.section_name).FirstOrDefault();
        //            model.EmployeeSettings = (from sect in dbContent.Section_Table
        //                                      where sect.section_num == kvp.Value && sect.open_label != kvp.Key
        //                                      select new SectionViewModel
        //                                      {
        //                                          SectionName = sect.section_name,
        //                                          SectionNumber = sect.section_num

        //                                      }).ToList();

        //        }

        //        if (kvp.Key == "Name")
        //        {
        //            ViewBag.Name = dbContent.Section_Table.Where(t => t.open_label.Contains(kvp.Key)).Select(z => z.section_name).FirstOrDefault();
        //            model.NameSettings = (from sect in dbContent.Section_Table
        //                                  where sect.section_num == kvp.Value && sect.open_label != kvp.Key
        //                                  select new SectionViewModel()
        //                                  {
        //                                      SectionName = sect.section_name,
        //                                      SectionNumber = sect.section_num

        //                                  }).ToList();

        //        }

        //    }

        //    return View("View", model);

        //}

    }
}