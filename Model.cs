public class WebAPIResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Response { get; set; }
        public dynamic DynamicData { get; set; }
    }

    public enum DataCollectionType { FlightAvailibility,Book,Reservation, PegasusAvailibility, TroyaAvailibility,TroyaBooking, TroyaCreateReservation,TroyaCancelReservation, TroyaRetrieveReservation, TroyaPurchaseBasket, TroyaGetFare,TroyaPrepayment, TroyaGetFareInitiate };

    public enum BasicFlightCabinType { ECONOMY,BUSINESS}
    public enum BasicFlightDesignCode { Y, C}

    public class BasicFlightRequest
    {
        public string RequestID { get; set; }
        public string OriginCode { get; set; }
        public string DestinationCode { get; set; }
        public string OriginName { get; set; }
        public string DestinationName { get; set; }
        
        [BsonRepresentation(BsonType.String)]
        public DateTime DepartureDate { get; set; }
        [BsonRepresentation(BsonType.String)]
        public DateTime? ReturnDate { get; set; }
        
        public bool IsRoundTrip { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
        
        public List<BasicFlightCabinType> CabinPreferences { get; set; }
        public bool DepartureAllAirports { get; set; }
        public bool ReturnAllAirports { get; set; }
    }

    public class BasicFlightSegment
    {
        public string OriginCode { get; set; }
        public string DestinationCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ArrivalTime { get; set; }
        public string OperatingAirline { get; set; }
        public string ResBookDesignCode { get; set; }
        public string BookingClass { get; set; }
        public string FlightNumber { get; set; }
        public bool IsConnected { get; set; }
        public int FlightSegmentIndex { get; set; }
        public int DepartureReturn { get; set; }
        public string BrandCode { get; set; }
        public BasicFlightCabinType FlightCabinType { get; set; }
        public string OfferID { get; set; }
        public string ResponseID { get; set; }
    }

    public class BasicPassenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string HesCode { get; set; }
        public string TurkishPublicID { get; set; }
        public string PassengerType { get; set; }
        public string PassengerTypeCode { get; set; }
        public string PassportNumber { get; set; }
        public string MilesNumber { get; set; }
        public int PassengerIndex { get; set; }
        public int PassengerRecordID { get; set; }
    }

    public class BasicContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
    }

    public class BasicReservationModel
    {
        public List<BasicFlightSegment> FlightSegments { get; set; }
        public List<BasicPassenger> Passengers { get; set; }
        public BasicContactInfo BasicContactInfo { get; set; }
        public string RequestID { get; set; }
        public int BookingID { get; set; }
    }
