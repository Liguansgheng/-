using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7LIB
{
    public class FN : compositeField
    {
        public FN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[5];
            data[0] = new ST("Surname");
            data[1] = new ST("Own Surname Prefix");
            data[2] = new ST("Own Surname");
            data[3] = new ST("Surname Prefix From Partner Or Spouse");
            data[4] = new ST("Surname From Partner Or Spouse");
        }
        public ST Surname
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST OwnSurnamePrefix
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST OwnSurname
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST SurnamePrefixFromPartnerOrSpouse
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST SurnameFromPartnerOrSpouse
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
    }

    public class PN : compositeField
    {
        public PN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[6];
            data[0] = new FN(this, "Family Name");
            data[1] = new ST("Given Name");
            data[2] = new ST("Second And Further Given Names Or Initials Thereof");
            data[3] = new ST("Suffix");
            data[4] = new ST("Prefix");
            data[5] = new IS("Degree");
        }
        public FN FamilyName
        {
            get { return data[0] as FN; }
            set { data[0] = value; }
        }
        public ST GivenName
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST SecondAndFurtherGivenNamesOrInitialsThereof
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST Suffix
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST Prefix
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
        public IS Degree
        {
            get { return data[5] as IS; }
            set { data[5] = value; }
        }
    }

    public class CE : compositeField
    {
        public CE(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[6];
            data[0] = new ST("Identifier");
            data[1] = new ST("Text");
            data[2] = new IS("Name Of Coding System");
            data[3] = new ST("Alternate Identifier");
            data[4] = new ST("Alternate Text");
            data[5] = new IS("Name Of Alternate Coding System");
        }
        public ST Identifier
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST Text
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public IS NameOfCodingSystem
        {
            get { return data[2] as IS; }
            set { data[2] = value; }
        }
        public ST AlternateIdentifier
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST AlternateText
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
        public IS NameOfAlternateCodingSystem
        {
            get { return data[5] as IS; }
            set { data[5] = value; }
        }
    }

    public class HD : compositeField
    {
        public HD(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new IS("Namespace ID");
            data[1] = new ST("Universal ID");
            data[2] = new ID("Universal ID Type");
        }
        public IS NamespaceID
        {
            get { return data[0] as IS; }
            set { data[0] = value; }
        }
        public ST UniversalID
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ID UniversalIDType
        {
            get { return data[2] as ID; }
            set { data[2] = value; }
        }
    }

    public class DR : compositeField
    {
        public DR(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[2];
            data[0] = new TS("Range Start Date Or Time");
            data[1] = new TS("Range End Date Or Time");
        }
        public TS RangeStartDateOrTime
        {
            get { return data[0] as TS; }
            set { data[0] = value; }
        }
        public TS RangeEndDateOrTime
        {
            get { return data[1] as TS; }
            set { data[1] = value; }
        }
    }
    public class XCN : compositeField
    {
        public XCN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[18];
            data[0] = new ST("ID Number");
            data[1] = new FN(this, "Family Name");
            data[2] = new ST("Given Name");
            data[3] = new ST("Second And Further Given Names Or Initials Thereof");
            data[4] = new ST("Suffix");
            data[5] = new ST("Prefix");
            data[6] = new IS("Degree");
            data[7] = new IS("Source Table");
            data[8] = new HD(this, "Assigning Authority");
            data[9] = new ID("Name Type Code");
            data[10] = new ST("Identifier Check Digit");
            data[11] = new ID("Code Identifying The Check Digit Scheme Employed");
            data[12] = new IS("Identifier Type Code");
            data[13] = new HD(this, "Assigning Facility");
            data[14] = new ID("Name Representation Code");
            data[15] = new CE(this, "Name Context");
            data[16] = new DR(this, "Name Validity Range");
            data[17] = new ID("Name Assembly Order");
        }
        public ST IDNumber
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public FN FamilyName
        {
            get { return data[1] as FN; }
            set { data[1] = value; }
        }
        public ST GivenName
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST SecondAndFurtherGivenNamesOrInitialsThereof
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST Suffix
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
        public ST Prefix
        {
            get { return data[5] as ST; }
            set { data[5] = value; }
        }
        public IS Degree
        {
            get { return data[6] as IS; }
            set { data[6] = value; }
        }
        public IS SourceTable
        {
            get { return data[7] as IS; }
            set { data[7] = value; }
        }
        public HD AssigningAuthority
        {
            get { return data[8] as HD; }
            set { data[8] = value; }
        }
        public ID NameTypeCode
        {
            get { return data[9] as ID; }
            set { data[9] = value; }
        }
        public ST IdentifierCheckDigit
        {
            get { return data[10] as ST; }
            set { data[10] = value; }
        }
        public ID CodeIdentifyingTheCheckDigitSchemeEmployed
        {
            get { return data[11] as ID; }
            set { data[11] = value; }
        }
        public IS IdentifierTypeCode
        {
            get { return data[12] as IS; }
            set { data[12] = value; }
        }
        public HD AssigningFacility
        {
            get { return data[13] as HD; }
            set { data[13] = value; }
        }
        public ID NameRepresentationCode
        {
            get { return data[14] as ID; }
            set { data[14] = value; }
        }
        public CE NameContext
        {
            get { return data[15] as CE; }
            set { data[15] = value; }
        }
        public DR NameValidityRange
        {
            get { return data[16] as DR; }
            set { data[16] = value; }
        }
        public ID NameAssemblyOrder
        {
            get { return data[17] as ID; }
            set { data[17] = value; }
        }
    }

    public class VID : compositeField
    {
        public VID(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new ID("Version ID");
            data[1] = new CE(this, "Internationalization Code");
            data[2] = new CE(this, "International Version ID");
        }
        public ID VersionID
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public CE InternationalizationCode
        {
            get { return data[1] as CE; }
            set { data[1] = value; }
        }
        public CE InternationalVersionID
        {
            get { return data[2] as CE; }
            set { data[2] = value; }
        }
    }

    public class PT : compositeField
    {
        public PT(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[2];
            data[0] = new ID("Processing ID");
            data[1] = new ID("Processing Mode");
        }
        public ID ProcessingID
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ID ProcessingMode
        {
            get { return data[1] as ID; }
            set { data[1] = value; }
        }
    }

    public class CM : compositeField
    {
        public CM(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new ID("Message Code");
            data[1] = new ID("Trigger Event");
            data[2] = new ID("Message Structure");
        }
        public ID MessageCode
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ID TriggerEvent
        {
            get { return data[1] as ID; }
            set { data[1] = value; }
        }
        public ID MessageStructure
        {
            get { return data[2] as ID; }
            set { data[2] = value; }
        }
    }

    public class EI : compositeField
    {
        public EI(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[4];
            data[0] = new ST("Entity Identifier");
            data[1] = new IS("Namespace ID");
            data[2] = new ST("Universal ID");
            data[3] = new ID("Universal ID Type");
        }
        public ST EntityIdentifier
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public IS NamespaceID
        {
            get { return data[1] as IS; }
            set { data[1] = value; }
        }
        public ST UniversalID
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ID UniversalIDType
        {
            get { return data[3] as ID; }
            set { data[3] = value; }
        }
    }

    public class CX : compositeField
    {
        public CX(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[8];
            data[0] = new ST("ID");
            data[1] = new ST("Check Digit");
            data[2] = new ID("Code Identifying The Check Digit Scheme Employed");
            data[3] = new HD(this,"Assigning Authority");
            data[4] = new ID("Identifier Type Code");
            data[5] = new HD(this,"Assigning Facility");
            data[6] = new DT("Effective Date");
            data[7] = new DT("Expiration Date");
        }
        public ST ID
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST CheckDigit
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ID CodeIdentifyingTheCheckDigitSchemeEmployed
        {
            get { return data[2] as ID; }
            set { data[2] = value; }
        }
        public HD AssigningAuthority
        {
            get { return data[3] as HD; }
            set { data[3] = value; }
        }
        public ID IdentifierTypeCode
        {
            get { return data[4] as ID; }
            set { data[4] = value; }
        }
        public HD AssigningFacility
        {
            get { return data[5] as HD; }
            set { data[5] = value; }
        }
        public DT EffectiveDate
        {
            get { return data[6] as DT; }
            set { data[6] = value; }
        }
        public DT ExpirationDate
        {
            get { return data[7] as DT; }
            set { data[7] = value; }
        }
    }

    public class XAD : compositeField
    {
        public XAD(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[11];
            data[0] = new ST("Street Address");
            data[1] = new ST("Other Designation");
            data[2] = new ST("City");
            data[3] = new ST("State Or Province");
            data[4] = new ST("Zip Or Postal Code");
            data[5] = new ID("Country");
            data[6] = new ID("Address Type");
            data[7] = new ST("Other Geographic Designation");
            data[8] = new IS("County Or Parish Code");
            data[9] = new IS("Census Tract");
            data[10] = new ID("Address Validity Range");
        }
        public ST StreetAddress
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST OtherDesignation
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST City
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST StateOrProvince
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST ZipOrPostalCode
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
        public ID Country
        {
            get { return data[5] as ID; }
            set { data[5] = value; }
        }
        public ID AddressType
        {
            get { return data[6] as ID; }
            set { data[6] = value; }
        }
        public ST OtherGeographicDesignation
        {
            get { return data[7] as ST; }
            set { data[7] = value; }
        }
        public IS CountyOrParishCode
        {
            get { return data[8] as IS; }
            set { data[8] = value; }
        }
        public IS CensusTract
        {
            get { return data[9] as IS; }
            set { data[9] = value; }
        }
        public ID AddressValidityRange
        {
            get { return data[10] as ID; }
            set { data[10] = value; }
        }
    }

    public class XTN : compositeField
    {
        public XTN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[9];
            data[0] = new ID("Telecommunication Use Code");
            data[1] = new ID("Telecommunication Equipment Type");
            data[2] = new ST("Email Address");
            data[3] = new NM("Country Code");
            data[4] = new NM("Area Or City Code");
            data[5] = new NM("Phone Number");
            data[6] = new NM("Extension");
            data[7] = new ST("Any Text");
            data[8] = new TN("CAnyText");  //[(999)] 999-9999 [X99999][C any text]
        }
        public ID TelecommunicationUseCode
        {
            get { return data[0] as ID; }
            set { data[0] = value; }
        }
        public ID TelecommunicationEquipmentType
        {
            get { return data[1] as ID; }
            set { data[1] = value; }
        }
        public ST EmailAddress
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public NM CountryCode
        {
            get { return data[3] as NM; }
            set { data[3] = value; }
        }
        public NM AreaOrCityCode
        {
            get { return data[4] as NM; }
            set { data[4] = value; }
        }
        public NM PhoneNumber
        {
            get { return data[5] as NM; }
            set { data[5] = value; }
        }
        public NM Extension
        {
            get { return data[6] as NM; }
            set { data[6] = value; }
        }
        public ST AnyText
        {
            get { return data[7] as ST; }
            set { data[7] = value; }
        }
        public TN CAnyText
        {
            get { return data[8] as TN; }
            set { data[8] = value; }
        }
    }

    public class DLN : compositeField
    {
        public DLN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[3];
            data[0] = new ST("Drivers License Number");
            data[1] = new IS("Issuing State Province Country");
            data[2] = new DT("Expiration Date");
        }
        public ST DriversLicenseNumber
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public IS IssuingStateProvinceCountry
        {
            get { return data[1] as IS; }
            set { data[1] = value; }
        }
        public DT ExpirationDate
        {
            get { return data[2] as DT; }
            set { data[2] = value; }
        }
    }

    public class PL : compositeField
    {
        public PL(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[9];
            data[0] = new IS("Point Of Care");
            data[1] = new IS("Room");
            data[2] = new IS("Bed");
            data[3] = new HD(this,"Facility");
            data[4] = new IS("Location Status");
            data[5] = new IS("Person Location Type");
            data[6] = new IS("Building");
            data[7] = new IS("Floor");
            data[8] = new ST("Location Description");
        }
        public IS PointOfCare
        {
            get { return data[0] as IS; }
            set { data[0] = value; }
        }
        public IS Room
        {
            get { return data[1] as IS; }
            set { data[1] = value; }
        }
        public IS Bed
        {
            get { return data[2] as IS; }
            set { data[2] = value; }
        }
        public HD Facility
        {
            get { return data[3] as HD; }
            set { data[3] = value; }
        }
        public IS LocationStatus
        {
            get { return data[4] as IS; }
            set { data[4] = value; }
        }
        public IS PersonLocationType
        {
            get { return data[5] as IS; }
            set { data[5] = value; }
        }
        public IS Building
        {
            get { return data[6] as IS; }
            set { data[6] = value; }
        }
        public IS Floor
        {
            get { return data[7] as IS; }
            set { data[7] = value; }
        }
        public ST LocationDescription
        {
            get { return data[8] as ST; }
            set { data[8] = value; }
        }
    }

    public class FC : compositeField
    {
        public FC(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[2];
            data[0] = new IS("Financial Class");
            data[1] = new TS("Effective Date");
        }
        public IS FinancialClass
        {
            get { return data[0] as IS; }
            set { data[0] = value; }
        }
        public TS EffectiveDate
        {
            get { return data[1] as TS; }
            set { data[1] = value; }
        }
    }

    public class XPN : compositeField
    {
        public XPN(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[11];
            data[0] = new FN(this, "Family Name");
            data[1] = new ST("Given Name");
            data[2] = new ST("Second And Further Given Names Or Initials Thereof");
            data[3] = new ST("Suffix");
            data[4] = new ST("Prefix");
            data[5] = new IS("Degree");
            data[6] = new ID("Name Type Code");
            data[7] = new ID("Name Representation Code");
            data[8] = new CE(this, "Name Context");
            data[9] = new DR(this, "Name Validity Range");
            data[10] = new ID("Name Assembly Order");
        }
        public FN FamilyName
        {
            get { return data[0] as FN; }
            set { data[0] = value; }
        }
        public ST GivenName
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public ST SecondAndFurtherGivenNamesOrInitialsThereof
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public ST Suffix
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST Prefix
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
        public IS Degree
        {
            get { return data[5] as IS; }
            set { data[5] = value; }
        }
        public ID NameTypeCode
        {
            get { return data[6] as ID; }
            set { data[6] = value; }
        }
        public ID NameRepresentationCode
        {
            get { return data[7] as ID; }
            set { data[7] = value; }
        }
        public CE NameContext
        {
            get { return data[8] as CE; }
            set { data[8] = value; }
        }
        public DR NameValidityRange
        {
            get { return data[9] as DR; }
            set { data[9] = value; }
        }
        public ID NameAssemblyOrder
        {
            get { return data[10] as ID; }
            set { data[10] = value; }
        }
    }

    public class XON : compositeField
    {
        public XON(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[10];
            data[0] = new ST("Organization Name");
            data[1] = new IS("Organization Name Type Code");
            data[2] = new NM("ID Number");
            data[3] = new NM("Check Digit");
            data[4] = new ID("Code Identifying The Check Digit Scheme Employed");
            data[5] = new HD(this, "Assigning Authority");
            data[6] = new IS("Identifier Type Code");
            data[7] = new HD(this, "Assigning Facility ID");
            data[8] = new HD(this, "ID");
            data[9] = new ID("Name Representation Code");
        }
        public ST OrganizationName
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public IS OrganizationNameTypeCode
        {
            get { return data[1] as IS; }
            set { data[1] = value; }
        }
        public NM IDNumber
        {
            get { return data[2] as NM; }
            set { data[2] = value; }
        }
        public NM CheckDigit
        {
            get { return data[3] as NM; }
            set { data[3] = value; }
        }
        public ID CodeIdentifyingTheCheckDigitSchemeEmployed
        {
            get { return data[4] as ID; }
            set { data[4] = value; }
        }
        public HD AssigningAuthority
        {
            get { return data[5] as HD; }
            set { data[5] = value; }
        }
        public IS IdentifierTypeCode
        {
            get { return data[6] as IS; }
            set { data[6] = value; }
        }
        public HD AssigningFacilityID
        {
            get { return data[7] as HD; }
            set { data[7] = value; }
        }
        public HD ID
        {
            get { return data[8] as HD; }
            set { data[8] = value; }
        }
        public ID NameRepresentationCode
        {
            get { return data[9] as ID; }
            set { data[9] = value; }
        }
    }

    public class CWE : compositeField
    {
        public CWE(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[9];
            data[0] = new ST("Identifier");
            data[1] = new ST("Text");
            data[2] = new IS("Name Of Coding System");
            data[3] = new ST("Alternate Identifier");
            data[4] = new ST("Alternate Text");
            data[5] = new IS("Name Of Alternate Coding System");
            data[6] = new ST("Coding System Version ID");
            data[7] = new ST("Alternate Coding System Version ID");
            data[8] = new ST("Original Text");
        }
        public ST Identifier
        {
            get { return data[0] as ST; }
            set { data[0] = value; }
        }
        public ST Text
        {
            get { return data[1] as ST; }
            set { data[1] = value; }
        }
        public IS NameOfCodingSystem
        {
            get { return data[2] as IS; }
            set { data[2] = value; }
        }
        public ST AlternateIdentifier
        {
            get { return data[3] as ST; }
            set { data[3] = value; }
        }
        public ST AlternateText
        {
            get { return data[4] as ST; }
            set { data[4] = value; }
        }
        public IS NameOfAlternateCodingSystem
        {
            get { return data[5] as IS; }
            set { data[5] = value; }
        }
        public ST CodingSystemVersionID
        {
            get { return data[6] as ST; }
            set { data[6] = value; }
        }
        public ST AlternateCodingSystemVersionID
        {
            get { return data[7] as ST; }
            set { data[7] = value; }
        }
        public ST OriginalText
        {
            get { return data[8] as ST; }
            set { data[8] = value; }
        }
    }

    public class CQ : compositeField
    {
        public CQ(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[2];
            data[0] = new NM("Quantity");
            data[1] = new CE(this, "Units");
        }
        public NM Quantity
        {
            get { return data[0] as NM; }
            set { data[0] = value; }
        }
        public CE Units
        {
            get { return data[1] as CE; }
            set { data[1] = value; }
        }
    }

    public class TQ : compositeField
    {
        public TQ(compositeType parent, string name) : base(parent, name)
        {
            data = new abstractType[12];
            data[0] = new CQ(this, "Quantity Component");
            data[1] = new CM(this, "Interval Component");
            data[2] = new ST("Duration Component");
            data[3] = new TS("Start Date Or Time Component");
            data[4] = new TS("End Date Or Time Component");
            data[5] = new ST("Priority Component");
            data[6] = new ST("Condition Component");
            data[7] = new TX("Text Component");
            data[8] = new ID("Conjunction Component");
            data[9] = new CM(this, "Order Sequencing Component");
            data[10] = new CE(this, "Occurrence Duration Component");
            data[11] = new NM("Total Occurrences Component");
        }
        public CQ QuantityComponent
        {
            get { return data[0] as CQ; }
            set { data[0] = value; }
        }
        public CM IntervalComponent
        {
            get { return data[1] as CM; }
            set { data[1] = value; }
        }
        public ST DurationComponent
        {
            get { return data[2] as ST; }
            set { data[2] = value; }
        }
        public TS StartDateOrTimeComponent
        {
            get { return data[3] as TS; }
            set { data[3] = value; }
        }
        public TS EndDateOrTimeComponent
        {
            get { return data[4] as TS; }
            set { data[4] = value; }
        }
        public ST PriorityComponent
        {
            get { return data[5] as ST; }
            set { data[5] = value; }
        }
        public ST ConditionComponent
        {
            get { return data[6] as ST; }
            set { data[6] = value; }
        }
        public TX TextComponent
        {
            get { return data[7] as TX; }
            set { data[7] = value; }
        }
        public ID ConjunctionComponent
        {
            get { return data[8] as ID; }
            set { data[8] = value; }
        }
        public CM OrderSequencingComponent
        {
            get { return data[9] as CM; }
            set { data[9] = value; }
        }
        public CE OccurrenceDurationComponent
        {
            get { return data[10] as CE; }
            set { data[10] = value; }
        }
        public NM TotalOccurrencesComponent
        {
            get { return data[11] as NM; }
            set { data[11] = value; }
        }
    }
}

