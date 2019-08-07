/*
 * Author-Name: Hasham Alam
 * Student-No: 991498453
 * Date: 7/23/2019
 */
using System.Runtime.Serialization;


namespace Hasham_991498453_Assignment_3
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }

    }
}