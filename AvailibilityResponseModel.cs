using APIModel.Helper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroyaRest.AvailibilityResponse
{

    public partial class AvailibilityResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("availabilityOTAResponse")]
        public AvailabilityOtaResponse AvailabilityOtaResponse { get; set; }
    }

    public partial class AvailabilityOtaResponse
    {
        [JsonProperty("extraOTABrandInfoList")]
        public ExtraOtaBrandInfoList ExtraOtaBrandInfoList { get; set; }

        [JsonProperty("createOTAAirRoute")]
        public CreateOtaAirRoute CreateOtaAirRoute { get; set; }

        [JsonProperty("isMixCabin")]
        public bool IsMixCabin { get; set; }
    }

    public partial class CreateOtaAirRoute
    {
        [JsonProperty("extraOTAAvailabilityInfoListType")]
        public ExtraOtaAvailabilityInfoListType ExtraOtaAvailabilityInfoListType { get; set; }

        [JsonProperty("OTA_AirAvailRS")]
        public OtaAirAvailRs OtaAirAvailRs { get; set; }
    }

    public partial class ExtraOtaAvailabilityInfoListType
    {
        [JsonProperty("extraOTAAvailabilityInfoList")]
        public ExtraOtaAvailabilityInfoList ExtraOtaAvailabilityInfoList { get; set; }
    }

    public partial class ExtraOtaAvailabilityInfoList
    {
        [JsonProperty("extraOTAFlightInfoListType")]
        public ExtraOtaFlightInfoListType ExtraOtaFlightInfoListType { get; set; }

        [JsonProperty("isAllFlightsFullCodeShare")]
        public bool IsAllFlightsFullCodeShare { get; set; }

        [JsonProperty("isIndeedHasMoreFlightsForAnotherPortInTheSameCity")]
        public bool IsIndeedHasMoreFlightsForAnotherPortInTheSameCity { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }
    }

    public partial class ExtraOtaFlightInfoListType
    {
        [JsonProperty("extraOTAFlightInfoList")]
        [JsonConverter(typeof(SingleArrayConverter<ExtraOtaFlightInfoList>))]
        public List<ExtraOtaFlightInfoList> ExtraOtaFlightInfoList { get; set; }
    }

    public partial class ExtraOtaFlightInfoList
    {
        [JsonProperty("isPureAnadoluJetFlight")]
        public bool IsPureAnadoluJetFlight { get; set; }

        [JsonProperty("extraOTASegmentInfoListType")]
        public ExtraOtaSegmentInfoListType ExtraOtaSegmentInfoListType { get; set; }

        [JsonProperty("isElectronicTicketAvailable")]
        public bool IsElectronicTicketAvailable { get; set; }

        [JsonProperty("isMarketable")]
        public bool IsMarketable { get; set; }

        [JsonProperty("isCodeShare")]
        public bool IsCodeShare { get; set; }

        [JsonProperty("isFullCodeShare")]
        public bool IsFullCodeShare { get; set; }

        [JsonProperty("miniRulesList")]
        public MiniRulesList MiniRulesList { get; set; }

        [JsonProperty("isDomestic")]
        public bool IsDomestic { get; set; }

        [JsonProperty("isFullInternational")]
        public bool IsFullInternational { get; set; }

        [JsonProperty("flightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("StandbyIndicator")]
        public bool StandbyIndicator { get; set; }

        [JsonProperty("bookingPriceInfoType")]
        public BookingPriceInfoType BookingPriceInfoType { get; set; }

        [JsonProperty("isFullAvailable")]
        public bool IsFullAvailable { get; set; }
    }

    public partial class BookingPriceInfoType
    {
        [JsonProperty("PTC_FareBreakdowns")]
        public PtcFareBreakdowns PtcFareBreakdowns { get; set; }
    }

    public partial class PtcFareBreakdowns
    {
        [JsonProperty("PTC_FareBreakdown")]
        [JsonConverter(typeof(SingleArrayConverter<PtcFareBreakdown>))]
        public List<PtcFareBreakdown> PtcFareBreakdown { get; set; }
    }

    public partial class PtcFareBreakdown
    {
        [JsonProperty("FareBasisCodes")]
        public FareBasisCodes FareBasisCodes { get; set; }

        [JsonProperty("PassengerTypeQuantity")]
        public PassengerTypeQuantity PassengerTypeQuantity { get; set; }

        [JsonProperty("FareInfo")]
        public PtcFareBreakdownFareInfo FareInfo { get; set; }

        [JsonProperty("PassengerFare")]
        public PassengerFare PassengerFare { get; set; }
    }

    public partial class FareBasisCodes
    {
        [JsonProperty("FareBasisCode")]
        [JsonConverter(typeof(SingleArrayConverter<FareBasisCode>))]
        public List<FareBasisCode> FareBasisCode { get; set; }
    }

    public partial class FareBasisCode
    {
        [JsonProperty("FlightSegmentRPH")]
        public string FlightSegmentRph { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class PtcFareBreakdownFareInfo
    {
        [JsonProperty("FareInfo")]
        [JsonConverter(typeof(SingleArrayConverter<FareInfoElement>))]
        public List<FareInfoElement> FareInfo { get; set; }

        [JsonProperty("PassengerFare")]
        public string PassengerFare { get; set; }

        [JsonProperty("FareReference")]
        [JsonConverter(typeof(SingleArrayConverter<FareReference>))]
        public List<FareReference> FareReference { get; set; }
    }

    public partial class FareInfoElement
    {
        [JsonProperty("FareType")]
        public string FareType { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }
    }

    public partial class FareReference
    {
        [JsonProperty("ResBookDesigCode")]
        public string ResBookDesigCode { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public partial class PassengerFare
    {
        [JsonProperty("TotalFare")]
        public BaseFare TotalFare { get; set; }

        [JsonProperty("Taxes")]
        public Taxes Taxes { get; set; }

        [JsonProperty("BaseFare")]
        public BaseFare BaseFare { get; set; }

        [JsonProperty("FareBaggageAllowance")]
        [JsonConverter(typeof(SingleArrayConverter<FareBaggageAllowance>))]
        public List<FareBaggageAllowance> FareBaggageAllowance { get; set; }
    }

    public partial class BaseFare
    {
        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }
    }

    public partial class FareBaggageAllowance
    {
        [JsonProperty("UnitOfMeasureCode")]
        public string UnitOfMeasureCode { get; set; }

        [JsonProperty("UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }

        [JsonProperty("UnitOfMeasureQuantity")]
        public string UnitOfMeasureQuantity { get; set; }

        [JsonProperty("FlightSegmentRPH")]
        public string FlightSegmentRph { get; set; }
    }

    public class Taxes
    {
        [JsonProperty("Tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SingleArrayConverter<TaxElement>))]
        public List<TaxElement> Tax { get; set; }
    }


    public partial class TaxElement
    {
        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("TaxCode")]
        public string TaxCode { get; set; }

        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("RefundableInd")]
        public bool RefundableInd { get; set; }
    }

    public partial class PassengerTypeQuantity
    {
        [JsonProperty("CodeContext")]
        public string CodeContext { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }
    }

    public partial class ExtraOtaSegmentInfoListType
    {
        [JsonProperty("extraOTASegmentInfoList")]
        [JsonConverter(typeof(SingleArrayConverter<ExtraOtaSegmentInfoList>))]
        public List<ExtraOtaSegmentInfoList> ExtraOtaSegmentInfoList { get; set; }
    }

    public partial class ExtraOtaSegmentInfoList
    {
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonProperty("isConnected")]
        public bool IsConnected { get; set; }

        [JsonProperty("segmentIndex")]
        public int SegmentIndex { get; set; }

        [JsonProperty("isAnadoluJetSegment")]
        public bool IsAnadoluJetSegment { get; set; }

        [JsonProperty("isDomestic")]
        public bool IsDomestic { get; set; }

        [JsonProperty("isStandBySeat")]
        public bool IsStandBySeat { get; set; }
    }

    public partial class MiniRulesList
    {
        [JsonProperty("MiniRules")]
        [JsonConverter(typeof(SingleArrayConverter<MiniRule>))]
        public List<MiniRule> MiniRules { get; set; }
    }

    public partial class MiniRule
    {
        [JsonProperty("PassengerType")]
        public string PassengerType { get; set; }

        [JsonProperty("MealCommercialName")]
        public string MealCommercialName { get; set; }

        [JsonProperty("CarryOnBaggageAllowance")]
        public BaggageAllowance CarryOnBaggageAllowance { get; set; }

        [JsonProperty("BrandCode")]
        public string BrandCode { get; set; }

        [JsonProperty("PenaltyMiniRule")]
        public PenaltyMiniRule PenaltyMiniRule { get; set; }

        [JsonProperty("BusinessLounge")]
        public string BusinessLounge { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("MealSubCode")]
        public string MealSubCode { get; set; }

        [JsonProperty("BrandKey")]
        public string BrandKey { get; set; }

        [JsonProperty("CheckedBaggageAllowance")]
        public BaggageAllowance CheckedBaggageAllowance { get; set; }
    }

    public partial class BaggageAllowance
    {
        [JsonProperty("FreeBaggageAllowance")]
        public FreeBaggageAllowance FreeBaggageAllowance { get; set; }
    }

    public partial class FreeBaggageAllowance
    {
        [JsonProperty("pieces")]
        public string Pieces { get; set; }

        [JsonProperty("kilos")]
        public string Kilos { get; set; }
    }

    public partial class PenaltyMiniRule
    {
        [JsonProperty("ChangePenaltyList")]
        public ChangePenaltyList ChangePenaltyList { get; set; }

        [JsonProperty("CancellationPenaltyList")]
        public CancellationPenaltyList CancellationPenaltyList { get; set; }
    }

    public partial class CancellationPenaltyList
    {
        [JsonProperty("CancellationPenalty")]
        [JsonConverter(typeof(SingleArrayConverter<CancellationPenalty>))]
        public List<CancellationPenalty> CancellationPenalty { get; set; }
    }

    public partial class CancellationPenalty
    {
        [JsonProperty("IsRefundable")]
        public bool IsRefundable { get; set; }

        [JsonProperty("TimeToDeparture")]
        public TimeToDeparture TimeToDeparture { get; set; }

        [JsonProperty("PercentageOrFixedAmount", NullValueHandling = NullValueHandling.Ignore)]
        public PercentageOrFixedAmount PercentageOrFixedAmount { get; set; }
    }

    public partial class PercentageOrFixedAmount
    {
        [JsonProperty("FixedAmount")]
        public BaseFare FixedAmount { get; set; }
    }

    public partial class TimeToDeparture
    {
        [JsonProperty("TimePeriodCondition")]
        public string TimePeriodCondition { get; set; }

        [JsonProperty("TimeUnit")]
        public string TimeUnit { get; set; }

        [JsonProperty("TimeAmount")]
        public string TimeAmount { get; set; }
    }

    public partial class ChangePenaltyList
    {
        [JsonProperty("ChangePenalty")]
        [JsonConverter(typeof(SingleArrayConverter<ChangePenalty>))]
        public List<ChangePenalty> ChangePenalty { get; set; }
    }

    public partial class ChangePenalty
    {
        [JsonProperty("TimeToDeparture")]
        public TimeToDeparture TimeToDeparture { get; set; }

        [JsonProperty("IsChangeable")]
        public bool IsChangeable { get; set; }

        [JsonProperty("PercentageOrFixedAmount", NullValueHandling = NullValueHandling.Ignore)]
        public PercentageOrFixedAmount PercentageOrFixedAmount { get; set; }
    }

    public partial class OtaAirAvailRs
    {
        [JsonProperty("Comment")]
        public string Comment { get; set; }

        [JsonProperty("OriginDestinationInformation")]
        public OriginDestinationInformation OriginDestinationInformation { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }
    }

    public partial class OriginDestinationInformation
    {
        [JsonProperty("OriginLocation")]
        public NLocation OriginLocation { get; set; }

        [JsonProperty("OriginDestinationOptions")]
        public OriginDestinationOptions OriginDestinationOptions { get; set; }

        [JsonProperty("DepartureDateTime")]
        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset DepartureDateTime { get; set; }

        [JsonProperty("ArrivalDateTime")]
        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset ArrivalDateTime { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }

        [JsonProperty("DestinationLocation")]
        public NLocation DestinationLocation { get; set; }
    }

    public partial class NLocation
    {
        [JsonProperty("AlternateLocationInd")]
        public bool AlternateLocationInd { get; set; }

        [JsonProperty("LocationCode")]
        public string LocationCode { get; set; }
    }

    public partial class OriginDestinationOptions
    {
        [JsonProperty("OriginDestinationOption")]
        [JsonConverter(typeof(SingleArrayConverter<OriginDestinationOption>))]
        public List<OriginDestinationOption> OriginDestinationOption { get; set; }
    }

    public partial class OriginDestinationOption
    {
        [JsonProperty("FlightSegment")]
        [JsonConverter(typeof(SingleArrayConverter<FlightSegment>))]
        public List<FlightSegment> FlightSegment { get; set; }
    }

    public partial class FlightSegment
    {
        [JsonProperty("DepartureAirport")]
        public Airport DepartureAirport { get; set; }

        [JsonProperty("Ticket")]
        public string Ticket { get; set; }

        [JsonProperty("ArrivalAirport")]
        public Airport ArrivalAirport { get; set; }

        [JsonProperty("BookingClassAvail")]
        [JsonConverter(typeof(SingleArrayConverter<BookingClassAvail>))]
        public List<BookingClassAvail> BookingClassAvail { get; set; }

        [JsonProperty("DateChangeNbr")]
        public bool DateChangeNbr { get; set; }

        [JsonProperty("StopQuantity")]
        public int StopQuantity { get; set; }

        [JsonProperty("GroundDuration", NullValueHandling = NullValueHandling.Ignore)]
        public string GroundDuration { get; set; }

        [JsonProperty("CodeshareInd")]
        public bool CodeshareInd { get; set; }

        [JsonProperty("Equipment")]
        public Equipment Equipment { get; set; }

        [JsonProperty("DepartureDateTime")]
        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset DepartureDateTime { get; set; }

        [JsonProperty("ArrivalDateTime")]
        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset ArrivalDateTime { get; set; }

        [JsonProperty("FlightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("OperatingAirline")]
        public OperatingAirline OperatingAirline { get; set; }

        [JsonProperty("JourneyDuration")]
        public string JourneyDuration { get; set; }
    }

    public partial class Airport
    {
        [JsonProperty("LocationCode")]
        public string LocationCode { get; set; }
    }

    public partial class BookingClassAvail
    {
        [JsonProperty("ResBookDesigQuantity")]
        public int ResBookDesigQuantity { get; set; }

        [JsonProperty("ResBookDesigStatusCode")]
        public string ResBookDesigStatusCode { get; set; }

        [JsonProperty("ResBookDesigCode")]
        public string ResBookDesigCode { get; set; }

        [JsonProperty("RPH")]
        public string Rph { get; set; }
    }

    public partial class Equipment
    {
        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("AirEquipType")]
        public string AirEquipType { get; set; }
    }

    public partial class OperatingAirline
    {
        [JsonProperty("CompanyShortName")]
        public string CompanyShortName { get; set; }
    }

    public partial class ExtraOtaBrandInfoList
    {
        [JsonProperty("fareBrandOtaResponseItems")]
        [JsonConverter(typeof(SingleArrayConverter<FareBrandOtaResponseItem>))]
        public List<FareBrandOtaResponseItem> FareBrandOtaResponseItems { get; set; }
    }

    public partial class FareBrandOtaResponseItem
    {
        [JsonProperty("BrandName")]
        public string BrandName { get; set; }

        [JsonProperty("BonusMile")]
        public bool BonusMile { get; set; }

        [JsonProperty("BrandCode")]
        public string BrandCode { get; set; }

        [JsonProperty("CarrierCode")]
        public string CarrierCode { get; set; }

        [JsonProperty("SeatSelection")]
        public bool SeatSelection { get; set; }

        [JsonProperty("BonusMileAmount")]
        public string BonusMileAmount { get; set; }

        [JsonProperty("BrandKey")]
        public string BrandKey { get; set; }

        [JsonProperty("BrandIndex")]
        public string BrandIndex { get; set; }
    }

    public partial class Message
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial struct TaxUnion
    {
        public TaxElement TaxElement;
        public List<TaxElement> TaxElementArray;

        public static implicit operator TaxUnion(TaxElement TaxElement) => new TaxUnion { TaxElement = TaxElement };
        public static implicit operator TaxUnion(List<TaxElement> TaxElementArray) => new TaxUnion { TaxElementArray = TaxElementArray };
    }


}
