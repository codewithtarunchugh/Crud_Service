using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Crud_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    [ServiceContract]
    public interface IWCFContact
    {

        [OperationContract]
        Int32 Insert(WCFContact ContactPar);

        [OperationContract]
        int Update(WCFContact ContactPar);

        [OperationContract]
        List<WCFContact> SelectAll();

        [OperationContract]
        int Delete(WCFContact ContactPar);
        // TODO: Add your service operations here
    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class WCFContact
    {
        private Int32 contactID;
        private String contactName;
        private String contactAddress;
        private String contactNumber;
        private DateTime contactDOB;
        private Decimal contactIncome;

        [DataMember]
        public Int32 ContactID
        {
            get
            {
                return contactID;
            }
            set
            {
                contactID = value;
            }
        }
        [DataMember]
        public string ContactName
        {
            get
            {
                return contactName;
            }
            set
            {
                contactName = value;
            }
        }
        [DataMember]
        public string ContactAddress
        {
            get
            {
                return contactAddress;
            }
            set
            {
                contactAddress = value;
            }
        }
        [DataMember]
        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }
            set
            {
                contactNumber = value;
            }
        }
        [DataMember]
        public DateTime ContactDOB
        {
            get
            {
                return contactDOB;
            }
            set
            {
                contactDOB = value;
            }
        }
        [DataMember]
        public decimal ContactIncome
        {
            get
            {
                return contactIncome;
            }
            set
            {
                contactIncome = value;
            }
        }
    }
}
