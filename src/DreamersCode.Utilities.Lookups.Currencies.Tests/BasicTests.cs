namespace DreamersCode.Utilities.Lookups.Currencies.Tests
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void FetchOneCurrency()
        {
            var result = CurrencyCollection.AllCurrencies.SingleOrDefault(x => x.AlphabeticCode.Equals("EUR", StringComparison.OrdinalIgnoreCase)); 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CheckCurrencyNumericCodeAsStringIsThreeCharacters()
        {            
           var result =  CurrencyCollection.AllCurrencies.SingleOrDefault(x => x.AlphabeticCode.Equals("BZD", StringComparison.OrdinalIgnoreCase)); 
            Assert.IsNotNull (result);
            Assert.AreEqual(3, result.NumericCodeAsString.Length);
        }


        [TestMethod]
        public void FetchMoreThenOneCurrency()
        {
            var result = CurrencyCollection.AllCurrencies.Where(x => x.NumericCode > 120);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.IsGreaterThan(1, result.Count());
        }
    }
}
