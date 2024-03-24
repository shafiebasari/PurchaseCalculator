using Web_API.Model;

namespace Domain
{
    public class Calculator
    {
        public VATCalculatorModel VATCalculator(double Price, double VAT, double PnV, double Percentage)
        {

            //missing percentage value
            if (Percentage == 0)
            {
                throw new Exception("Percentage value is missing or not valid.");
            }

            //missing all value
            if (Price == 0 && VAT == 0 && PnV == 0)
            {
                throw new Exception("All value is missing or not valid.");
            }

            //more that 1 value inserted
            if ((Price != 0 && VAT != 0) || (Price != 0 && PnV != 0) || (VAT != 0 && PnV != 0))
            {
                throw new Exception("More than 1 value inserted.");
            }

            Percentage /= 100;
             
            //Price Inserted
            if (Price != 0)
            {
                VAT = Price * Percentage;
                PnV = Price + VAT;
            }else if (VAT != 0)
            {
                Price = VAT / Percentage;
                PnV = Price + VAT;
            }else if (PnV != 0)
            {
                Price = PnV / (Percentage + 1);
                VAT = PnV - Price;
            }

            VATCalculatorModel result = new()
            {
                Price = Math.Round(Price, 2),
                VAT = Math.Round(VAT, 2),
                Pnv = Math.Round(PnV, 2)
            };

            return result;
        }
    }
}