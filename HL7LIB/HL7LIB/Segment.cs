using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7LIB
{
    public class MSH : compositeSegment
    {
        public MSH(compositeType parent) : base(parent, "MSH")
        {
            data = new abstractType[21];
            data[0] = new ST("Field Separator");
            data[1] = new ST("Encoding Characters");
            data[2] = new HD(this,"Sending Application");
            data[3] = new HD(this, "Sending Facility");
            data[4] = new HD(this, "Receiving Application");
            data[5] = new HD(this, "Receiving Facility");
            data[6] = new TS("DateOrTime Of Message");
            data[7] = new ST("Security");
            data[8] = new CM(this, "Message Type");
            data[9] = new ST("Message Control ID");
            data[10] = new PT(this, "Processing ID");
            data[11] = new VID(this, "Version ID");
            data[12] = new NM("Sequence Number");
            data[13] = new ST("Continuation Pointer");
            data[14] = new ID("Accept Acknowledgment Type");
            data[15] = new ID("Application AcknowledgmentType");
            data[16] = new ID("Country Code");
            data[17] = new ID("Character Set");
            data[18] = new CE(this, "Principal Language Of Message");
            data[19] = new ID("Alternate Character SetHandlingScheme");
            data[20] = new EI(this, "Message Profile Identifier");
        }
        public ST FieldSeparator
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST EncodingCharacters
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public HD SendingApplication
        {
            get { return data[2] as HD; }
            set { data[2] = value; }
        }
        public HD SendingFacility
        {
            get { return data[3] as HD; }
            set { data[3] = value; }
        }
        public HD ReceivingApplication
        {
            get { return data[4] as HD; }
            set { data[4] = value; }
        }
        public HD ReceivingFacility
        {
            get { return data[5] as HD; }
            set { data[5] = value; }
        }
        public TS DateOrTimeOfMessage
        {
            get { return data[6] as TS; }
            set { data[6] = value; }
        }
        public ST Security
        {
            get { return data[7] as ST; }
            set { data[7] = value; }
        }
        public CM MessageType
        {
            get { return data[8] as CM; }
            set { data[8] = value; }
        }
        public ST MessageControlID
        {
            get { return data[9] as ST; }
            set { data[9] = value; }
        }
        public PT ProcessingID
        {
            get { return data[10] as PT; }
            set { data[10] = value; }
        }
        public VID VersionID
        {
            get { return data[11] as VID; }
            set { data[11] = value; }
        }
        public NM SequenceNumber
        {
            get { return data[12] as NM; }
            set { data[12] = value; }
        }
        public ST ContinuationPointer
        {
            get { return data[13] as ST; }
            set { data[13] = value; }
        }
        public ID AcceptAcknowledgmentType
        {
            get { return data[14] as ID; }
            set { data[14] = value; }
        }
        public ID ApplicationAcknowledgmentType
        {
            get { return data[15] as ID; }
            set { data[15] = value; }
        }
        public ID CountryCode
        {
            get { return data[16] as ID; }
            set { data[16] = value; }
        }
        public ID CharacterSet
        {
            get { return data[17] as ID; }
            set { data[17] = value; }
        }
        public CE PrincipalLanguageOfMessage
        {
            get { return data[18] as CE; }
            set { data[18] = value; }
        }
        public ID AlternateCharacterSetHandlingScheme
        {
            get { return data[19] as ID; }
            set { data[19] = value; }
        }
        public EI MessageProfileIdentifier
        {
            get { return data[20] as EI; }
            set { data[20] = value; }
        }
    }

    public class MSA : compositeSegment
    {
        public MSA(compositeType parent) : base(parent, "MSA")
        {
            data = new abstractType[6];
            data[0] = new ID("Acknowledgment Code");
            data[1] = new ST("Message Control ID");
            data[2] = new ST("Text Message");
            data[3] = new NM("Expected Sequence Number");
            data[4] = new ID("Delayed Acknowledgment Type");
            data[5] = new CE(this,"Error Condition");
        }
        public ID AcknowledgmentCode
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ST MessageControlID
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST TextMessage
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public NM ExpectedSequenceNumber
        {
            get { return data[3] as NM; }
            set { data[3] = value; }
        }
        public ID DelayedAcknowledgmentType
        {
            get { return data[4] as ID; }
            set { data[4] = value; }
        }
        public CE ErrorCondition
        {
            get { return data[5] as CE; }
            set { data[5] = value; }
        }
    }

    public class PID : compositeSegment
    {
        public PID(compositeType parent) : base(parent, "PID")
        {
            data = new abstractType[38];
            data[0] = new SI("Set ID PID");
            data[1] = new CX(this,"Patient ID");
            data[2] = new CX(this, "Patient Identifier List");
            data[3] = new CX(this, "Alternate Patient ID PID");
            data[4] = new XPN(this, "Patient Name");
            data[5] = new XPN(this, "Mothers Maiden Name");
            data[6] = new TS("Date Or Time Of Birth");
            data[7] = new IS("Administrative Sex"); //
            data[8] = new XPN(this, "Patient Alias");
            data[9] = new CE(this, "Race");
            data[10] = new XAD(this, "Patient Address");
            data[11] = new IS("County Code");
            data[12] = new XTN(this, "Phone Number Home");
            data[13] = new XTN(this, "Phone Number Business");
            data[14] = new CE(this, "Primary Language");
            data[15] = new CE(this, "Marital Status");
            data[16] = new CE(this, "Religion");
            data[17] = new CX(this, "Patient Account Number");
            data[18] = new ST("SSN Number Patient");
            data[19] = new DLN(this, "Drivers License Number Patient");
            data[20] = new CX(this, "Mothers Identifier");
            data[21] = new CE(this, "Ethnic Group");
            data[22] = new ST("Birth Place");
            data[23] = new ID("Multiple Birth Indicator");
            data[24] = new NM("Birth Order");
            data[25] = new CE(this, "Citizenship");
            data[26] = new CE(this, "Veterans Military Status");
            data[27] = new CE(this, "Nationality");
            data[28] = new TS("Patient Death Date And Time");
            data[29] = new ID("Patient Death Indicator");
            data[30] = new ID("Identity Unknown Indicator");
            data[31] = new IS("Identity Beliability Code");
            data[32] = new TS("Last Update Date Or Time");
            data[33] = new HD(this,"Last Update Facility");
            data[34] = new CE(this,"Species Code");
            data[35] = new CE(this, "Breed Code");
            data[36] = new CE(this, "Strain");
            data[37] = new ST("Production Class Code");
        }
        public SI SetIDPID
        {
            get { return data[0] as SI; }
            set { data[0] = value; }
        }
        public CX PatientID
        {
            get { return data[1] as CX; }
            set { data[1] = value; }
        }
        public CX PatientIdentifierList
        {
            get { return data[2] as CX; }
            set { data[2] = value; }
        }
        public CX AlternatePatientIDPID
        {
            get { return data[3] as CX; }
            set { data[3] = value; }
        }
        public XPN PatientName
        {
            get { return data[4] as XPN; }
            set { data[4] = value; }
        }
        public XPN MothersMaidenName
        {
            get { return data[5] as XPN; }
            set { data[5] = value; }
        }
        public TS DateOrTimeOfBirth
        {
            get { return data[6] as TS; }
            set { data[6] = value; }
        }
        public IS Sex
        {
            get { return data[7] as IS; }
            set { data[7] = value; }
        }
        public XPN PatientAlias
        {
            get { return data[8] as XPN; }
            set { data[8] = value; }
        }
        public CE Race
        {
            get { return data[9] as CE; }
            set { data[9] = value; }
        }
        public XAD PatientAddress
        {
            get { return data[10] as XAD; }
            set { data[10] = value; }
        }
        public IS CountyCode
        {
            get { return data[11] as IS; }
            set { data[11] = value; }
        }
        public XTN PhoneNumberHome
        {
            get { return data[12] as XTN; }
            set { data[12] = value; }
        }
        public XTN PhoneNumberBusiness
        {
            get { return data[13] as XTN; }
            set { data[13] = value; }
        }
        public CE PrimaryLanguage
        {
            get { return data[14] as CE; }
            set { data[14] = value; }
        }
        public CE MaritalStatus
        {
            get { return data[15] as CE; }
            set { data[15] = value; }
        }
        public CE Religion
        {
            get { return data[16] as CE; }
            set { data[16] = value; }
        }
        public CX PatientAccountNumber
        {
            get { return data[17] as CX; }
            set { data[17] = value; }
        }
        public ST SSNNumberPatient
        {
            get { return data[18] as ST; }
            set { data[18] = value; }
        }
        public DLN DriversLicenseNumberPatient
        {
            get { return data[19] as DLN; }
            set { data[19] = value; }
        }
        public CX MothersIdentifier
        {
            get { return data[20] as CX; }
            set { data[20] = value; }
        }
        public CE EthnicGroup
        {
            get { return data[21] as CE; }
            set { data[21] = value; }
        }
        public ST BirthPlace
        {
            get { return data[22] as ST; }
            set { data[22] = value; }
        }
        public ID MultipleBirthIndicator
        {
            get { return data[23] as ID; }
            set { data[23] = value; }
        }
        public NM BirthOrder
        {
            get { return data[24] as NM; }
            set { data[24] = value; }
        }
        public CE Citizenship
        {
            get { return data[25] as CE; }
            set { data[25] = value; }
        }
        public CE VeteransMilitaryStatus
        {
            get { return data[26] as CE; }
            set { data[26] = value; }
        }
        public CE Nationality
        {
            get { return data[27] as CE; }
            set { data[27] = value; }
        }
        public TS PatientDeathDateAndTime
        {
            get { return data[28] as TS; }
            set { data[28] = value; }
        }
        public ID PatientDeathIndicator
        {
            get { return data[29] as ID; }
            set { data[29] = value; }
        }
        public ID IdentityUnknownIndicator
        {
            get { return data[30] as ID; }
            set { data[30] = value; }
        }
        public IS IdentityBeliabilityCode
        {
            get { return data[31] as IS; }
            set { data[31] = value; }
        }
        public TS LastUpdateDateOrTime
        {
            get { return data[32] as TS; }
            set { data[32] = value; }
        }
        public HD LastUpdateFacility
        {
            get { return data[33] as HD; }
            set { data[33] = value; }
        }
        public CE SpeciesCOde
        {
            get { return data[34] as CE; }
            set { data[34] = value; }
        }
        public CE BreedCode
        {
            get { return data[35] as CE; }
            set { data[35] = value; }
        }
        public CE Strain
        {
            get { return data[36] as CE; }
            set { data[36] = value; }
        }
        public ST ProductionClassCode
        {
            get { return data[37] as ST; }
            set { data[37] = value; }
        }
    }

    public class PV1 : compositeSegment
    {
        public PV1(compositeType parent) : base(parent, "PV1")
        {
            data = new abstractType[52];
            data[0] = new SI("Set ID PV1");
            data[1] = new IS("Patient Class");
            data[2] = new PL(this,"Assigned Patient Location");
            data[3] = new IS("Admission Type");
            data[4] = new CX(this, "Preadmit Number");
            data[5] = new PL(this, "Prior Patient Location");
            data[6] = new XCN(this, "Attending Doctor");
            data[7] = new XCN(this, "Referring Doctor");
            data[8] = new XCN(this, "Consulting Doctor");
            data[9] = new IS("Hospital Service");
            data[10] = new PL(this, "Temporary Location");
            data[11] = new IS("Preadmit Test Indicator");
            data[12] = new IS("Re Admission Indicator");
            data[13] = new IS("Admit Source");
            data[14] = new IS("Ambulatory Status");
            data[15] = new IS("VIP Indicator");
            data[16] = new XCN(this, "Admitting Doctor");
            data[17] = new IS("Patient Type");
            data[18] = new CX(this, "Visit Number");
            data[19] = new FC(this, "Financial Class");
            data[20] = new IS("Charge Price Indicator");
            data[21] = new IS("Courtesy Code");
            data[22] = new IS("Credit Rating");
            data[23] = new IS("Contract Code");
            data[24] = new DT("Contract Effective Date");
            data[25] = new NM("Contract Amount");
            data[26] = new NM("Contract Period");
            data[27] = new IS("Interest Code");
            data[28] = new IS("Transfer To Bad Debt Code");
            data[29] = new DT("Transfer To Bad Debt Date");
            data[30] = new IS("Bad Debt Agency Code");
            data[31] = new NM("Bad Debt Transfer Amount");
            data[32] = new NM("Bad Debt Recovery Amount");
            data[33] = new IS("Delete Account Indicator");
            data[34] = new DT("Delete Account Date");
            data[35] = new IS("Discharge Disposition");
            data[36] = new CM(this, "Discharged To Location");
            data[37] = new CE(this, "Diet Type");
            data[38] = new IS("Servicing Facility");
            data[39] = new IS("Bed Status");
            data[40] = new IS("Account Status");
            data[41] = new PL(this, "Pending Location");
            data[42] = new PL(this, "Prior Temporary Location");
            data[43] = new TS("Admit Date Or Time");
            data[44] = new TS("Discharge Date Or Time");
            data[45] = new NM("Current Patient Balance");
            data[46] = new NM("Total Charges");
            data[47] = new NM("Total Adjustments");
            data[48] = new NM("Total Payments");
            data[49] = new CX(this, "Alternate Visit ID");
            data[50] = new IS("Visit Indicator");
            data[51] = new XCN(this, "Other Healthcare Provider");
        }
        public SI SetIDPV1
        {
            get { return data[0] as SI; }
            set { data[0] = value; }
        }
        public IS PatientClass
        {
            get { return data[1] as IS; }
            set { data[1] = value; }
        }
        public PL AssignedPatientLocation
        {
            get { return data[2] as PL; }
            set { data[2] = value; }
        }
        public IS AdmissionType
        {
            get { return data[3] as IS; }
            set { data[3] = value; }
        }
        public CX PreadmitNumber
        {
            get { return data[4] as CX; }
            set { data[4] = value; }
        }
        public PL PriorPatientLocation
        {
            get { return data[5] as PL; }
            set { data[5] = value; }
        }
        public XCN AttendingDoctor
        {
            get { return data[6] as XCN; }
            set { data[6] = value; }
        }
        public XCN ReferringDoctor
        {
            get { return data[7] as XCN; }
            set { data[7] = value; }
        }
        public XCN ConsultingDoctor
        {
            get { return data[8] as XCN; }
            set { data[8] = value; }
        }
        public IS HospitalService
        {
            get { return data[9] as IS; }
            set { data[9] = value; }
        }
        public PL TemporaryLocation
        {
            get { return data[10] as PL; }
            set { data[10] = value; }
        }
        public IS PreadmitTestIndicator
        {
            get { return data[11] as IS; }
            set { data[11] = value; }
        }
        public IS ReAdmissionIndicator
        {
            get { return data[12] as IS; }
            set { data[12] = value; }
        }
        public IS AdmitSource
        {
            get { return data[13] as IS; }
            set { data[13] = value; }
        }
        public IS AmbulatoryStatus
        {
            get { return data[14] as IS; }
            set { data[14] = value; }
        }
        public IS VIPIndicator
        {
            get { return data[15] as IS; }
            set { data[15] = value; }
        }
        public XCN AdmittingDoctor
        {
            get { return data[16] as XCN; }
            set { data[16] = value; }
        }
        public IS PatientType
        {
            get { return data[17] as IS; }
            set { data[17] = value; }
        }
        public CX VisitNumber
        {
            get { return data[18] as CX; }
            set { data[18] = value; }
        }
        public FC FinancialClass
        {
            get { return data[19] as FC; }
            set { data[19] = value; }
        }
        public IS ChargePriceIndicator
        {
            get { return data[20] as IS; }
            set { data[20] = value; }
        }
        public IS CourtesyCode
        {
            get { return data[21] as IS; }
            set { data[21] = value; }
        }
        public IS CreditRating
        {
            get { return data[22] as IS; }
            set { data[22] = value; }
        }
        public IS ContractCode
        {
            get { return data[23] as IS; }
            set { data[23] = value; }
        }
        public DT ContractEffectiveDate
        {
            get { return data[24] as DT; }
            set { data[24] = value; }
        }
        public NM ContractAmount
        {
            get { return data[25] as NM; }
            set { data[25] = value; }
        }
        public NM ContractPeriod
        {
            get { return data[26] as NM; }
            set { data[26] = value; }
        }
        public IS InterestCode
        {
            get { return data[27] as IS; }
            set { data[27] = value; }
        }
        public IS TransferToBadDebtCode
        {
            get { return data[28] as IS; }
            set { data[28] = value; }
        }
        public DT TransferToBadDebtDate
        {
            get { return data[29] as DT; }
            set { data[29] = value; }
        }
        public IS BadDebtAgencyCode
        {
            get { return data[30] as IS; }
            set { data[30] = value; }
        }
        public NM BadDebtTransferAmount
        {
            get { return data[31] as NM; }
            set { data[31] = value; }
        }
        public NM BadDebtRecoveryAmount
        {
            get { return data[32] as NM; }
            set { data[32] = value; }
        }
        public IS DeleteAccountIndicator
        {
            get { return data[33] as IS; }
            set { data[33] = value; }
        }
        public DT DeleteAccountDate
        {
            get { return data[34] as DT; }
            set { data[34] = value; }
        }
        public IS DischargeDisposition
        {
            get { return data[35] as IS; }
            set { data[35] = value; }
        }
        public CM DischargedToLocation
        {
            get { return data[36] as CM; }
            set { data[36] = value; }
        }
        public CE DietType
        {
            get { return data[37] as CE; }
            set { data[37] = value; }
        }
        public IS ServicingFacility
        {
            get { return data[38] as IS; }
            set { data[38] = value; }
        }
        public IS BedStatus
        {
            get { return data[39] as IS; }
            set { data[39] = value; }
        }
        public IS AccountStatus
        {
            get { return data[40] as IS; }
            set { data[40] = value; }
        }
        public PL PendingLocation
        {
            get { return data[41] as PL; }
            set { data[41] = value; }
        }
        public PL PriorTemporaryLocation
        {
            get { return data[42] as PL; }
            set { data[42] = value; }
        }
        public TS AdmitDateOrTime
        {
            get { return data[43] as TS; }
            set { data[43] = value; }
        }
        public TS DischargeDateOrTime
        {
            get { return data[44] as TS; }
            set { data[44] = value; }
        }
        public NM CurrentPatientBalance
        {
            get { return data[45] as NM; }
            set { data[45] = value; }
        }
        public NM TotalCharges
        {
            get { return data[46] as NM; }
            set { data[46] = value; }
        }
        public NM TotalAdjustments
        {
            get { return data[47] as NM; }
            set { data[47] = value; }
        }
        public NM TotalPayments
        {
            get { return data[48] as NM; }
            set { data[48] = value; }
        }
        public CX AlternateVisitID
        {
            get { return data[49] as CX; }
            set { data[49] = value; }
        }
        public IS VisitIndicator
        {
            get { return data[50] as IS; }
            set { data[50] = value; }
        }
        public XCN OtherHealthcareProvider
        {
            get { return data[51] as XCN; }
            set { data[51] = value; }
        }
    }

    public class EVN : compositeSegment
    {
        public EVN(compositeType parent) : base(parent, "EVN")
        {
            data = new abstractType[7];
            data[0] = new ID("Event Type Code");
            data[1] = new TS("Recorded Date Or Time");
            data[2] = new TS("Date Or Time Planned Event");
            data[3] = new IS("Event Reason Code");
            data[4] = new XCN(this,"Operator ID");
            data[5] = new TS("Event Occurred");
            data[6] = new HD(this,"Event Facility ");
        }
        public ID EventTypeCode
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public TS RecordedDateOrTime
        {
            get { return data[1] as TS; }
            set { data[1] = value; }
        }
        public TS DateOrTimePlannedEvent
        {
            get { return data[2] as TS; }
            set { data[2] = value; }
        }
        public IS EventReasonCode
        {
            get { return data[3] as IS; }
            set { data[3] = value; }
        }
        public XCN OperatorID
        {
            get { return data[4] as XCN; }
            set { data[4] = value; }
        }
        public TS EventOccurred
        {
            get { return data[5] as TS; }
            set { data[5] = value; }
        }
        public HD EventFacility
        {
            get { return data[6] as HD; }
            set { data[6] = value; }
        }
    }

    public class ERR : compositeSegment
    {
        public ERR(compositeType parent) : base(parent, "ERR")
        {
            data = new abstractType[1];
            data[0] = new CM(this,"Error Code And Location");
        }
        public CM ErrorCodeAndLocation
        {
            get { return data[0] as CM; }
            set { data[0] = value; }
        }
    }

    public class ORC : compositeSegment
    {
        public ORC(compositeType parent) : base(parent, "ORC")
        {
            data = new abstractType[25];
            data[0] = new ID("Order Control");
            data[1] = new EI(this,"Placer Order Number");
            data[2] = new EI(this,"Filler Order Number");
            data[3] = new EI(this,"Placer Group Number");
            data[4] = new ID("Order Status");
            data[5] = new ID("Response Flag");
            data[6] = new TQ(this,"QuantityOrTiming");
            data[7] = new CM(this,"Parent");
            data[8] = new TS("DateOrTime Of Transaction");
            data[9] = new XCN(this,"Entered By");
            data[10] = new XCN(this,"Verified By");
            data[11] = new XCN(this,"Ordering Provider");
            data[12] = new PL(this,"S Location");
            data[13] = new XTN(this,"Call Back Phone Number");
            data[14] = new TS("Order Effective DateOrTime");
            data[15] = new CE(this,"Order Control Code Reason");
            data[16] = new CE(this,"Entering Organization");
            data[17] = new CE(this,"Entering Device");
            data[18] = new XCN(this,"Action By");
            data[19] = new CE(this,"Advanced Beneficiary Notice Code");
            data[20] = new XON(this, "Ordering Facility Name");
            data[21] = new XAD(this, "Ordering Facility Address");
            data[22] = new XTN(this, "Ordering Facility Phone Number");
            data[23] = new XAD(this, "Ordering Provider Address");
            data[24] = new CWE(this, "Order Status Modifier");
        }
        public ID OrderControl
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public EI PlacerOrderNumber
        {
            get { return data[1] as EI; }
            set { data[1] = value; }
        }
        public EI FillerOrderNumber
        {
            get { return data[2] as EI; }
            set { data[2] = value; }
        }
        public EI PlacerGroupNumber
        {
            get { return data[3] as EI; }
            set { data[3] = value; }
        }
        public ID OrderStatus
        {
            get { return data[4] as ID; }
            set { data[4] = value; }
        }
        public ID ResponseFlag
        {
            get { return data[5] as ID; }
            set { data[5] = value; }
        }
        public TQ QuantityOrTiming
        {
            get { return data[6] as TQ; }
            set { data[6] = value; }
        }
        public CM Parent
        {
            get { return data[7] as CM; }
            set { data[7] = value; }
        }
        public TS DateOrTimeOfTransaction
        {
            get { return data[8] as TS; }
            set { data[8] = value; }
        }
        public XCN EnteredBy
        {
            get { return data[9] as XCN; }
            set { data[9] = value; }
        }
        public XCN VerifiedBy
        {
            get { return data[10] as XCN; }
            set { data[10] = value; }
        }
        public XCN OrderingProvider
        {
            get { return data[11] as XCN; }
            set { data[11] = value; }
        }
        public PL SLocation
        {
            get { return data[12] as PL; }
            set { data[12] = value; }
        }
        public XTN CallBackPhoneNumber
        {
            get { return data[13] as XTN; }
            set { data[13] = value; }
        }
        public TS OrderEffectiveDateOrTime
        {
            get { return data[14] as TS; }
            set { data[14] = value; }
        }
        public CE OrderControlCodeReason
        {
            get { return data[15] as CE; }
            set { data[15] = value; }
        }
        public CE EnteringOrganization
        {
            get { return data[16] as CE; }
            set { data[16] = value; }
        }
        public CE EnteringDevice
        {
            get { return data[17] as CE; }
            set { data[17] = value; }
        }
        public XCN ActionBy
        {
            get { return data[18] as XCN; }
            set { data[18] = value; }
        }
        public CE AdvancedBeneficiaryNoticeCode
        {
            get { return data[19] as CE; }
            set { data[19] = value; }
        }
        public XON OrderingFacilityName
        {
            get { return data[20] as XON; }
            set { data[20] = value; }
        }
        public XAD OrderingFacilityAddress
        {
            get { return data[21] as XAD; }
            set { data[21] = value; }
        }
        public XTN OrderingFacilityPhoneNumber
        {
            get { return data[22] as XTN; }
            set { data[22] = value; }
        }
        public XAD OrderingProviderAddress
        {
            get { return data[23] as XAD; }
            set { data[23] = value; }
        }
        public CWE OrderStatusModifier
        {
            get { return data[24] as CWE; }
            set { data[24] = value; }
        }
    }

    public class OBR : compositeSegment
    {
        public OBR(compositeType parent) : base(parent, "OBR")
        {
            data = new abstractType[47];
            data[0] = new SI("Set ID OBR");
            data[1] = new EI(this,"Placer Order Number");
            data[2] = new EI(this, "Filler Order Number");
            data[3] = new CE(this, "Universal Service Identifier");
            data[4] = new ID("Priority OBR");
            data[5] = new TS("Requested DateOrTime");
            data[6] = new TS("Observation DateOrTime");
            data[7] = new TS("Observation End DateOrTime");
            data[8] = new CQ(this, "Collection Volume");
            data[9] = new XCN(this, "Collector Identifier");
            data[10] = new ID("Specimen Action Code");
            data[11] = new CE(this, "Danger Code");
            data[12] = new ST("Relevant Clinical Information");
            data[13] = new TS("Specimen Received DateOrTime");
            data[14] = new CM(this, "Specimen Source");
            data[15] = new XCN(this, "Ordering Provider");
            data[16] = new XTN(this, "Order Callback Phone Number");
            data[17] = new ST("Placer Field One");
            data[18] = new ST("Placer Field Two");
            data[19] = new ST("Filler Field One");
            data[20] = new ST("Filler Field Two");
            data[21] = new TS("Results RptOrStatus Chng DateOrTime");
            data[22] = new CM(this, "Charge To Practice");
            data[23] = new ID("Diagnostic Serv Sect ID");
            data[24] = new ID("Result Status");
            data[25] = new CM(this, "Parent Result");
            data[26] = new TQ(this, "QuantityOrTiming");
            data[27] = new XCN(this, "Result Copies To");
            data[28] = new CM(this, "Parent");
            data[29] = new ID("Transportation Mode");
            data[30] = new CE(this, "Reason For Study");
            data[31] = new CM(this, "Principal Result Interpreter");
            data[32] = new CM(this, "Assistant Result Interpreter");
            data[33] = new CM(this, "Technician");
            data[34] = new CM(this, "Transcriptionist");
            data[35] = new TS("Scheduled DateOrTime");
            data[36] = new NM("Number Of Sample Containers");
            data[37] = new CE(this, "Transport Logistics Of Collected Sample");
            data[38] = new CE(this, "Collectors Comment");
            data[39] = new CE(this, "Transport Arrangement Responsibility");
            data[40] = new ID("Transport Arranged");
            data[41] = new ID("Escort Required");
            data[42] = new CE(this, "Planned Patient Transport Comment");
            data[43] = new CE(this, "Procedure Code");
            data[44] = new CE(this, "Procedure Code Modifier");
            data[45] = new CE(this, "Placer Supplemental Service Information");
            data[46] = new CE(this, "Filler Supplemental Service Information");
        }
        public SI SetIDOBR
        {
            get { return data[0] as SI; }
            set { data[0] = value; }
        }
        public EI PlacerOrderNumber
        {
            get { return data[1] as EI; }
            set { data[1] = value; }
        }
        public EI FillerOrderNumber
        {
            get { return data[2] as EI; }
            set { data[2] = value; }
        }
        public CE UniversalServiceIdentifier
        {
            get { return data[3] as CE; }
            set { data[3] = value; }
        }
        public ID PriorityOBR
        {
            get { return data[4] as ID; }
            set { data[4] = value; }
        }
        public TS RequestedDateOrTime
        {
            get { return data[5] as TS; }
            set { data[5] = value; }
        }
        public TS ObservationDateOrTime
        {
            get { return data[6] as TS; }
            set { data[6] = value; }
        }
        public TS ObservationEndDateOrTime
        {
            get { return data[7] as TS; }
            set { data[7] = value; }
        }
        public CQ CollectionVolume
        {
            get { return data[8] as CQ; }
            set { data[8] = value; }
        }
        public XCN CollectorIdentifier
        {
            get { return data[9] as XCN; }
            set { data[9] = value; }
        }
        public ID SpecimenActionCode
        {
            get { return data[10] as ID; }
            set { data[10] = value; }
        }
        public CE DangerCode
        {
            get { return data[11] as CE; }
            set { data[11] = value; }
        }
        public ST RelevantClinicalInformation
        {
            get { return data[12] as ST; }
            set { data[12] = value; }
        }
        public TS SpecimenReceivedDateOrTime
        {
            get { return data[13] as TS; }
            set { data[13] = value; }
        }
        public CM SpecimenSource
        {
            get { return data[14] as CM; }
            set { data[14] = value; }
        }
        public XCN OrderingProvider
        {
            get { return data[15] as XCN; }
            set { data[15] = value; }
        }
        public XTN OrderCallbackPhoneNumber
        {
            get { return data[16] as XTN; }
            set { data[16] = value; }
        }
        public ST PlacerFieldOne
        {
            get { return data[17] as ST; }
            set { data[17] = value; }
        }
        public ST PlacerFieldTwo
        {
            get { return data[18] as ST; }
            set { data[18] = value; }
        }
        public ST FillerFieldOne
        {
            get { return data[19] as ST; }
            set { data[19] = value; }
        }
        public ST FillerFieldTwo
        {
            get { return data[20] as ST; }
            set { data[20] = value; }
        }
        public TS ResultsRptOrStatusChngDateOrTime
        {
            get { return data[21] as TS; }
            set { data[21] = value; }
        }
        public CM ChargeToPractice
        {
            get { return data[22] as CM; }
            set { data[22] = value; }
        }
        public ID DiagnosticServSectID
        {
            get { return data[23] as ID; }
            set { data[23] = value; }
        }
        public ID ResultStatus
        {
            get { return data[24] as ID; }
            set { data[24] = value; }
        }
        public CM ParentResult
        {
            get { return data[25] as CM; }
            set { data[25] = value; }
        }
        public TQ QuantityOrTiming
        {
            get { return data[26] as TQ; }
            set { data[26] = value; }
        }
        public XCN ResultCopiesTo
        {
            get { return data[27] as XCN; }
            set { data[27] = value; }
        }
        public CM Parent
        {
            get { return data[28] as CM; }
            set { data[28] = value; }
        }
        public ID TransportationMode
        {
            get { return data[29] as ID; }
            set { data[29] = value; }
        }
        public CE ReasonForStudy
        {
            get { return data[30] as CE; }
            set { data[30] = value; }
        }
        public CM PrincipalResultInterpreter
        {
            get { return data[31] as CM; }
            set { data[31] = value; }
        }
        public CM AssistantResultInterpreter
        {
            get { return data[32] as CM; }
            set { data[32] = value; }
        }
        public CM Technician
        {
            get { return data[33] as CM; }
            set { data[33] = value; }
        }
        public CM Transcriptionist
        {
            get { return data[34] as CM; }
            set { data[34] = value; }
        }
        public TS ScheduledDateOrTime
        {
            get { return data[35] as TS; }
            set { data[35] = value; }
        }
        public NM NumberOfSampleContainers
        {
            get { return data[36] as NM; }
            set { data[36] = value; }
        }
        public CE TransportLogisticsOfCollectedSample
        {
            get { return data[37] as CE; }
            set { data[37] = value; }
        }
        public CE CollectorsComment
        {
            get { return data[38] as CE; }
            set { data[38] = value; }
        }
        public CE TransportArrangementResponsibility
        {
            get { return data[39] as CE; }
            set { data[39] = value; }
        }
        public ID TransportArranged
        {
            get { return data[40] as ID; }
            set { data[40] = value; }
        }
        public ID EscortRequired
        {
            get { return data[41] as ID; }
            set { data[41] = value; }
        }
        public CE PlannedPatientTransportComment
        {
            get { return data[42] as CE; }
            set { data[42] = value; }
        }
        public CE ProcedureCode
        {
            get { return data[43] as CE; }
            set { data[43] = value; }
        }
        public CE ProcedureCodeModifier
        {
            get { return data[44] as CE; }
            set { data[44] = value; }
        }
        public CE PlacerSupplementalServiceInformation
        {
            get { return data[45] as CE; }
            set { data[45] = value; }
        }
        public CE FillerSupplementalServiceInformation
        {
            get { return data[46] as CE; }
            set { data[46] = value; }
        }
    }
}
