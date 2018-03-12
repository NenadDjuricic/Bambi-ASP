using TestDataBase;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;


namespace TestDataBase.ViewModel
{
    public class DeteIndexViewModel
    {
        public IQueryable<Dete> Dete { get; set; }
        public IPagedList<Dete> Detes { get; set; }
        public string Search { get; set; }
     
        public IEnumerable<VaspitnaWithCount> VaspitnaWithCount { get; set; }
        public string VaspitnaGrupa { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }

        public IEnumerable<SelectListItem> VasFilterItems
        {
            get
            {
                var svaDeca = VaspitnaWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.VaspitnaIme,
                    Text = cc.VaspitnaImeWithCount
                });
                return svaDeca;
            }
        }
    }
    public class VaspitnaWithCount
    {
        public int DecaCount { get; set; }
        public string VaspitnaIme { get; set; }
        public string VaspitnaImeWithCount
        {
            get
            {
                return VaspitnaIme + " (" + DecaCount.ToString() + ")";
            }
        }
    }

}