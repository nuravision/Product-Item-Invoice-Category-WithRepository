using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IInvoiceService
    {
        void Create(Invoice item);
        void Delete(Invoice item);
        void Edit(Invoice item);
        Invoice GetById(int id);
        List<Invoice> GetAll();
    }
}
