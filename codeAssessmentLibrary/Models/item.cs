using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeAssessmentLibrary.Models
{
    public class Item
    {
        public Item(decimal ItemShelfCost, string ItemName, Tax Taxes, ulong ItemQuantity)
        {
            this.ItemShelfCost = ItemShelfCost;
            this.ItemName = ItemName;
            this.ItemQuantity = ItemQuantity;
            this.Taxes = Taxes;
        }
        internal string ItemName;
        internal ulong ItemQuantity;
        readonly Tax Taxes;
        internal decimal ItemShelfCost;
        internal decimal ItemImportTaxTotal
        {
            get { return Taxes.CalcImportTax(ItemShelfCost); }
        }
        internal decimal ItemSalesTaxTotal
        {
            get { return Taxes.CalcSalesTax(ItemShelfCost); }
        }
        internal decimal ItemTotalCost
        {
            get
            {
                return ItemShelfCost + ItemSalesTaxTotal + ItemImportTaxTotal;
            }
        }
    }
}
