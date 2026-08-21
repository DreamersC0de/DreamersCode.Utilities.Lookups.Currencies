#if NET8_0_OR_GREATER
using System.Collections.Frozen;
#endif
using System.Collections.Generic;

namespace DreamersCode.Utilities.Lookups.Currencies.Models
{
    /// <summary>
    /// Provides display information for the given currency
    /// </summary>
    public record DisplayInfo
    {
        /// <summary>
        /// The Three letter code representing language code (based on the ISO-639-2)
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// The way the record needs to be displayed for the given language
        /// </summary>
        public string DisplayValue { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="langCode">The Three letter code representing language code (based on the ISO-639-2)</param>
        /// <param name="displayValue">The way the record needs to be displayed for the given language</param>
        public DisplayInfo(string langCode, string displayValue)
        {
            LanguageCode = langCode;
            DisplayValue = displayValue;
        }

    }
    /// <summary>
    /// Model representation of a currency as per ISO 4217
    /// </summary>
    public record Currency
    {
        /// <summary>
        /// The alphabetic code is based on another ISO standard, ISO 3166, which lists the codes for country names. 
        /// The first two letters of the ISO 4217 three-letter code are the same as the code for the country name, and, where possible, 
        /// the third letter corresponds to the first letter of the currency name.
        /// For example:
        /// The US dollar is represented as USD – the US coming from the ISO 3166 country code and the D for dollar.
        /// The Swiss franc is represented by CHF – the CH being the code for Switzerland in the ISO 3166 code and F for franc.
        /// </summary>
        public string AlphabeticCode { get; private set; }

        /// <summary>
        /// ISO 4217 The three-digit numeric code is useful when currency codes need to be understood in countries that do not use Latin scripts and for computerized systems. 
        /// Where possible, the three-digit numeric code is the same as the numeric country code
        /// In this case, the numeric value is padded to adhere to the 3 digit standard
        /// </summary>
        public string NumericCodeAsString { get { return NumericCode.ToString("000"); } }

        /// <summary>
        /// ISO 4217 The three-digit numeric code is useful when currency codes need to be understood in countries that do not use Latin scripts and for computerized systems. 
        /// Where possible, the three-digit numeric code is the same as the numeric country code
        /// </summary>
        public short NumericCode { get; private set; }

        /// <summary>
        /// The symbol used to represent the currency (might not be available)
        /// </summary>
        public string? CurrencySymbol { get; private set; }

        /// <summary>
        /// The amount of minor units that make a whole
        /// </summary>
        public short MinorUnit { get; private set; }

#if NET8_0_OR_GREATER
        /// <summary>
        /// The names of the currency for a given language code.  English is always present, other languages might be missing
        /// </summary>
        public FrozenSet<DisplayInfo> CurrencyNames { get; internal set; }
#else
        /// <summary>
        /// The names of the currency for a given language code.  English is always present, other languages might be missing
        /// </summary>
        public IReadOnlyCollection<DisplayInfo> CurrencyNames{ get; internal set; }
#endif


#if NET8_0_OR_GREATER
        /// <summary>
        /// The name of the fractional unit for the currency
        /// </summary>
        public FrozenSet<DisplayInfo> FractionalUnitNames { get; internal set; }
#else
        /// <summary>
        /// The name of the fractional unit for the currency
        /// </summary>
        public  IReadOnlyCollection<DisplayInfo> FractionalUnitNames{ get; internal set; }
#endif

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="alphabeticCode">The alphabetic code of the currency</param>
        /// <param name="numericCode">The numeric representation of the currency</param>
        /// <param name="currencySymbol">The symbol (if exists) for the currency</param>
        /// <param name="minorUnit">The number of units needed to form the whole currency</param>
        /// <param name="currencyNames">Names for the currency based on the language code</param>
        /// <param name="fractionalUnitNames">Names for the currency fractional unit based on the language code</param>
        public Currency(string alphabeticCode, short numericCode, string? currencySymbol,short minorUnit, List<DisplayInfo> currencyNames, List<DisplayInfo> fractionalUnitNames)
        {
            AlphabeticCode = alphabeticCode;
            NumericCode = numericCode;
            CurrencySymbol = currencySymbol;
#if NET8_0_OR_GREATER
            CurrencyNames = currencyNames.ToFrozenSet();
#else
            CurrencyNames = currencyNames;
#endif

#if NET8_0_OR_GREATER
            FractionalUnitNames = fractionalUnitNames.ToFrozenSet();
#else
            FractionalUnitNames = fractionalUnitNames;
#endif
            MinorUnit = minorUnit;
        }
    }
}
