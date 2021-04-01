            BasicFlightRequest flighRequest = new BasicFlightRequest()
            {
                Adult = 1,
                Child = 0,
                Infant = 0,
                CabinPreferences = new List<BasicFlightCabinType>() { BasicFlightCabinType.ECONOMY },
                RequestID = $"{Guid.NewGuid()}",
                IsRoundTrip = false,
                DepartureDate = DateTime.Parse("2021-04-20"),
                ReturnDate = null,
                OriginCode = "SAW",
                DestinationCode = "ADA"
            };


            TroyaRest.APIRequester requester = new APIRequester();
            WebAPIResponse response=requester.GetAvailibility(flighRequest)
