namespace EmergencyRoadSideAssistanceService.Model
{
    public class Assistant : IComparable<Assistant>
    {
        /// <summary>
        /// Service Provider Unique Identifier
        /// </summary>
        public string ProviderdId { get; set; }
        // <summary>
        /// Service Provider Company Name
        /// </summary>
        public string ProviderName { get; set; }
        // <summary>
        /// Indicate whether he is available at present to serve a customer
        /// </summary>
        public bool IsAvailable { get; set; }
        // <summary>
        /// Service Provider current location
        /// </summary>
        public GeoLocation CurrentLocation { get; set; }
        // <summary>
        /// Customers Unique Identifier referenced as a foreign key
        /// </summary>
        public string CustomerId { get; set; }
        // <summary>
        /// Referencing the Customer currently serviced by the Assistant
        /// </summary>
        public Customer Customer { get; set; }

        public int CompareTo(Assistant? assistant)
        {
            return this.CurrentLocation.Distance.CompareTo(assistant.CurrentLocation.Distance);
        }
    }
}
