# DreamersCode.Utilities.Lookups.Currencies

## Introduction 
A .Net lib that offers a lists of all the currencies as per ISO-4217 in a handy lookup mode.

# Getting Started
## How To Use
1. Download the package from Nuget.org (Package name: DreamersCode.Utilities.Lookups.Currencies)
2. The static class "CurrencyCollection" offers up a property "AllCurrencies" which allows you to enumerate through all the currencies or filter using LINQ.
    1. **.Net 8 upwards**: The list defaults to a FrozenSet that prioritises read speed for faster queries
    2. **.Net Standard 2.0 & 2.1**: The list defaults to IReadOnlyList    

# Example usage:
```
var result = CurrencyCollection.AllCurrencies
    .SingleOrDefault(x => x.AlphabeticCode.Equals("EUR", StringComparison.OrdinalIgnoreCase));
Console.WriteLine($"Currency Name In English {result.CurrencyNames.Single(x => x.LanguageCode.Equals("eng", StringComparison.OrdinalIgnoreCase))}");
Console.WriteLine($"Currency Symbol {result.CurrencySymbol}");
```

# Release Notes
Version 2.0.0 (Rel Date: 21/08/2026)
- Migrated from Azure Devops to GitHub as repository host
- Dropped support for .Net framework 4.6 but left .Net Standard 2.0 for legacy systems
- Added support for .Net 10


Version 1.0.2 (Rel Date: 17/02/2024)
- Updated url to new package location
 
Version 1.0.1 (Rel Date: 17/02/2024)
- turned lookups to frozen sets as well, improved output compilation

Version 1.0.0 (Rel Date: 11/02/2024)
- Initial Version

# Contribute
Feel free to send any feedback or suggestions to suggestions@dreamerscode.com