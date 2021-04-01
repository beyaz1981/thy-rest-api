
namespace TroyaRest.AvailibilityRequest
{
    /****Availibility Request*/
    public partial class AvailibilityRequestModel
    {
        [JsonProperty("requestHeader", NullValueHandling = NullValueHandling.Ignore)]
        public RequestHeader RequestHeader { get; set; }

        [JsonProperty("ReducedDataIndicator", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReducedDataIndicator { get; set; }

        [JsonProperty("RoutingType", NullValueHandling = NullValueHandling.Ignore)]
        public string RoutingType { get; set; }

        [JsonProperty("TargetSource", NullValueHandling = NullValueHandling.Ignore)]
        public string TargetSource { get; set; }

        [JsonProperty("PassengerTypeQuantity", NullValueHandling = NullValueHandling.Ignore)]
        public List<PassengerTypeQuantity> PassengerTypeQuantity { get; set; }

        [JsonProperty("OriginDestinationInformation", NullValueHandling = NullValueHandling.Ignore)]
        public List<OriginDestinationInformation> OriginDestinationInformation { get; set; }
    }

    public partial class OriginDestinationInformation
    {
        [JsonProperty("DepartureDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DepartureDateTime DepartureDateTime { get; set; }

        [JsonProperty("OriginLocation", NullValueHandling = NullValueHandling.Ignore)]
        public NLocation OriginLocation { get; set; }

        [JsonProperty("DestinationLocation", NullValueHandling = NullValueHandling.Ignore)]
        public NLocation DestinationLocation { get; set; }

        [JsonProperty("CabinPreferences", NullValueHandling = NullValueHandling.Ignore)]
        public List<CabinPreference> CabinPreferences { get; set; }
    }

    public partial class CabinPreference
    {
        [JsonProperty("Cabin", NullValueHandling = NullValueHandling.Ignore)]
        public string Cabin { get; set; }
    }

    public partial class DepartureDateTime
    {
        [JsonProperty("WindowAfter", NullValueHandling = NullValueHandling.Ignore)]
        public string WindowAfter { get; set; }

        [JsonProperty("WindowBefore", NullValueHandling = NullValueHandling.Ignore)]
        public string WindowBefore { get; set; }

        [JsonProperty("Date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get; set; }
    }

    public partial class NLocation
    {
        [JsonProperty("LocationCode", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationCode { get; set; }

        [JsonProperty("MultiAirportCityInd", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MultiAirportCityInd { get; set; }
    }

    public partial class PassengerTypeQuantity
    {
        [JsonProperty("Code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("Quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int Quantity { get; set; }
    }

    public partial class RequestHeader
    {
        [JsonProperty("clientUsername", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientUsername { get; set; }

        [JsonProperty("clientTransactionId", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientTransactionId { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public string Channel { get; set; }
    }
    /*Availibility Request *****/


}
