using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarPizzaShop.Models.ViewModels
{
    public class MenuViewModel
    {
        public Menu Menu { get; set; }
        public IEnumerable<PackInc> PackIncs { get; set; }
        public IEnumerable<SelectListItem> SelectListItems(IEnumerable<PackInc> Items)
        {
            List<SelectListItem> PackIncList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "---Select---",
                Value = "0"
            };

            PackIncList.Add(sli);
            foreach (PackInc packInc in Items)
            {
                sli = new SelectListItem
                {
                    Text = packInc.Name,
                    Value = packInc.Id.ToString()
                };
                PackIncList.Add(sli);
            }

            return PackIncList;
        }
    }

}
