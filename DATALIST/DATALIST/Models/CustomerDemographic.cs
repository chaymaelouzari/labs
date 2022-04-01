using System;
using System.Collections.Generic;

#nullable disable

namespace DATALIST.Models
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            CustomerCustomerDemos = new HashSet<CustomerCustomerDemo>();
        }

        public string CustomerTypeID { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
    }
}
