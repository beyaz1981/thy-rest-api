namespace TroyaRest
{
    public class APIRequester
    {
        private APIClient client { get; set; }
        public APIRequester()
        {
            client = new APIClient();
        }

       
	    public WebAPIResponse GetAvailibility(BasicFlightRequest flightRequest)
        {

            List<string> months = new List<string>() { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };


            AvailibilityRequest.AvailibilityRequestModel availibility = new AvailibilityRequest.AvailibilityRequestModel();
            availibility.RequestHeader = new AvailibilityRequest.RequestHeader
            {
                Channel = WebSettings.TroyaRest.Channel,
                ClientUsername = WebSettings.TroyaRest.ClientUsername,
                ClientTransactionId = flightRequest.RequestID,
            };
            availibility.ReducedDataIndicator = false;
            availibility.RoutingType = flightRequest.IsRoundTrip? RoutingType.R.ToString(): RoutingType.O.ToString();
            availibility.TargetSource = WebSettings.TroyaRest.TargetSource;
            availibility.PassengerTypeQuantity = new List<AvailibilityRequest.PassengerTypeQuantity>()
            {
                new AvailibilityRequest.PassengerTypeQuantity() { Code = PassengerTypeCode.adult.ToString(), Quantity = flightRequest.Adult },
                new AvailibilityRequest.PassengerTypeQuantity() { Code = PassengerTypeCode.child.ToString(), Quantity = flightRequest.Child },
                new AvailibilityRequest.PassengerTypeQuantity() { Code = PassengerTypeCode.infant.ToString(), Quantity = flightRequest.Infant }
            };

            

            availibility.OriginDestinationInformation = new List<AvailibilityRequest.OriginDestinationInformation>()
            {
                new AvailibilityRequest.OriginDestinationInformation()
                {
                    OriginLocation = new AvailibilityRequest.NLocation(){LocationCode=flightRequest.OriginCode, MultiAirportCityInd=flightRequest.DepartureAllAirports},
                    DestinationLocation = new AvailibilityRequest.NLocation(){LocationCode=flightRequest.DestinationCode, MultiAirportCityInd=flightRequest.ReturnAllAirports},
                    DepartureDateTime = new AvailibilityRequest.DepartureDateTime()
                    {
                        Date=$"{flightRequest.DepartureDate.Day}{months[flightRequest.DepartureDate.Month-1]}",
                        WindowAfter=WebSettings.TroyaRest.WindowAfter,
                        WindowBefore=WebSettings.TroyaRest.WindowBefore
                    },
                    CabinPreferences=new List<AvailibilityRequest.CabinPreference>(){}
                },
            };

            foreach (BasicFlightCabinType cabinType in flightRequest.CabinPreferences)
            {
                availibility.OriginDestinationInformation[0].CabinPreferences.Add(new AvailibilityRequest.CabinPreference() { Cabin = cabinType.ToString() });
            }


            if (flightRequest.IsRoundTrip)
            {
                availibility.OriginDestinationInformation.Add(
                    new AvailibilityRequest.OriginDestinationInformation()
                    {
                        OriginLocation = new AvailibilityRequest.NLocation() { LocationCode = flightRequest.DestinationCode, MultiAirportCityInd = flightRequest.DepartureAllAirports },
                        DestinationLocation = new AvailibilityRequest.NLocation() { LocationCode = flightRequest.OriginCode, MultiAirportCityInd = flightRequest.ReturnAllAirports },
                        DepartureDateTime = new AvailibilityRequest.DepartureDateTime()
                        {
                            Date = $"{flightRequest.ReturnDate.Value.Day}{months[flightRequest.ReturnDate.Value.Month-1]}",
                            WindowAfter = WebSettings.TroyaRest.WindowAfter,
                            WindowBefore = WebSettings.TroyaRest.WindowBefore
                        },
                        CabinPreferences = new List<AvailibilityRequest.CabinPreference>(){}
                    }
                );

                foreach (BasicFlightCabinType cabinType in flightRequest.CabinPreferences)
                {
                    availibility.OriginDestinationInformation[1].CabinPreferences.Add(new AvailibilityRequest.CabinPreference() { Cabin = cabinType.ToString() });
                }

            };


            WebAPIResponse model = client.Availibility(availibility);


            if (WebSettings.TroyaRest.StoreAvailibilityData == true)
            {
                if (model.Success == true)
                {
                    MongoEntity<AvailibilityResponse.AvailibilityResponse> mongoEntity = new MongoEntity<AvailibilityResponse.AvailibilityResponse>();
                    mongoEntity.Response = (AvailibilityResponse.AvailibilityResponse)model.DynamicData;
                    mongoEntity.RequestID = flightRequest.RequestID;
                    mongoEntity.CollectionName = DataCollectionType.TroyaAvailibility.ToString();
                    mongoEntity.Request = flightRequest;
                    mongoEntity.Insert();
                }
                else
                {
                    MongoEntity<FailedResponse.FailedRespone> mongoEntity = new MongoEntity<FailedResponse.FailedRespone>();
                    mongoEntity.Response = (FailedResponse.FailedRespone)model.DynamicData;
                    mongoEntity.RequestID = flightRequest.RequestID;
                    mongoEntity.CollectionName = DataCollectionType.TroyaAvailibility.ToString();
                    mongoEntity.Request = flightRequest;
                    mongoEntity.Insert();
                }
            }


            return model;
        }



    }




}
