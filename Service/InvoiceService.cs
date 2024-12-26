using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IVoiceRepository _invoiceRepository ;
        public InvoiceService()
        {
            _invoiceRepository=new InvoiceRepository();
        }
        public void Create(Invoice item)
        {
            _invoiceRepository.Create(item);
        }

        public void Delete(Invoice item)
        {
            _invoiceRepository.Delete(item);
        }

        public void Edit(Invoice item)
        {
            _invoiceRepository.Edit(item);
        }

        public List<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }

        public Invoice GetById(int id)
        {
            return _invoiceRepository.GetById(id);
        }
    }
}
