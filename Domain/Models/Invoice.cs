using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Invoice:BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public List<Item> Items { get; set; }

    }
}
