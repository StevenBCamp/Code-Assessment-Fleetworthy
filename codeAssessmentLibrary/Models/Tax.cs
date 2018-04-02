using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeAssessmentLibrary.Models
{
    public class Tax
    {
        private const decimal salesTax = 0.1M;
        private const decimal importedTax = 0.05M;
        readonly bool isSalesTax;
        readonly bool isImported;

        public Tax(bool IsSalesTax, bool IsImported)
        {
            isSalesTax = IsSalesTax;
            isImported = IsImported;
        }

        internal decimal CalcSalesTax(decimal itemShelfCost)
        {
            if (isSalesTax == true)
                return Math.Ceiling((itemShelfCost * salesTax) * 20) / 20;
            else
                return 0;
        }

        internal decimal CalcImportTax(decimal itemShelfCost)
        {
            if (isImported == true)
                return Math.Ceiling((itemShelfCost * importedTax) * 20) / 20;
            else
                return 0;
        }
    }
}
