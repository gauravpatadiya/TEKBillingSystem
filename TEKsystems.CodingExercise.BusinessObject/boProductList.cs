#region Namespaces

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKsystems.CodingExercise.DataObject;

#endregion

namespace TEKsystems.CodingExercise.BusinessObject
{
    public class boProductList
    {
        //public doProductList idoProductList { get; set; }

        public Collection<doProductList> iclcProductList = new Collection<doProductList>();

        public Collection<doProductList> GetProductList()
        { 
        
        }
    }
}
