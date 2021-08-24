using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFConsoleConsume
{
    class Program
    {
        static void Main(string[] args)
        {
            serviceRef.WCFContactClient objClient = new serviceRef.WCFContactClient();
            serviceRef.WCFContact objContact = new serviceRef.WCFContact();
            objContact.ContactName = "Darsh Chugh";
            objContact.ContactNumber = "9871943768";
            objContact.ContactIncome = 50000;
            objContact.ContactAddress = "981 Sector 9A";
            objContact.ContactDOB = DateTime.Now;
            //var ID = objClient.Insert(objContact);
            objContact.ContactID = 1;
            //var ID = objClient.Update(objContact);
            //var GotData = objClient.SelectAll();
            var roweffected = objClient.Delete(objContact);
            var refreshData = objClient.SelectAll();

        }
    }
}
