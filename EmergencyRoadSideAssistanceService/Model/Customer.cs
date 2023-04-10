namespace EmergencyRoadSideAssistanceService.Model
{
    public class Customer
    {
        // <summary>
        /// Customers Unique Identifier
        /// </summary>
        public string CustomerId { get; set; }
        // <summary>
        /// Customers policies, asssuming a customer can have more than one policy at a time.
        /// </summary>
        public List<string> PolicyList { get; set; }
        // <summary>
        /// Customers Full Name
        /// </summary>
        public string CustomerName { get; set; }
        // <summary>
        /// Customers Contact Number
        /// </summary>
        public string CustomerPhone { get; set; }
        // <summary>
        /// Customers VIN Number
        /// </summary>
        public string VIN { get; set; }

        //public string ProviderdId { get; set; }
        //public Assistant Assistant { get; set; }
    }
}
