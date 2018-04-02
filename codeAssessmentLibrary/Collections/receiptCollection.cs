using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codeAssessmentLibrary.Models;

namespace codeAssessmentLibrary.Collections
{
    public class ReceiptCollection : IList<Item>
    {
        internal List<Item> receiptList;
        public ReceiptCosts amounts;

        public int Count => ((IList<Item>)receiptList).Count;

        public bool IsReadOnly => ((IList<Item>)receiptList).IsReadOnly;

        public Item this[int index] { get => ((IList<Item>)receiptList)[index]; set => ((IList<Item>)receiptList)[index] = value; }

        public ReceiptCollection()
        {
            receiptList = new List<Item>();
            amounts = new ReceiptCosts();
        }

        #region Calculate Collection
        void CalcSalesTax()
        {
            //Use linq to gather all the data from the collection and store it into a list where it can then be summed together
            amounts.receiptTotalTax = receiptList.Where(a => a.ItemQuantity > 0)
                .Select(a => new List<decimal> { a.ItemSalesTaxTotal, a.ItemImportTaxTotal }).ToList()
                .Sum(z => z[0] + z[1]);
        }

        void CalcTotalCost()
        {
            amounts.receiptTotalCost = receiptList.Where(a => a.ItemQuantity > 0)
                .Select(a => a.ItemTotalCost).ToList()
                .Sum(z => z);
        }
        #endregion

        public void Display()
        {
            foreach (var item in receiptList)
                Console.WriteLine("{0} {1}: {2}", item.ItemQuantity, item.ItemName, item.ItemTotalCost);
            Console.WriteLine("Sales Taxes: {0}", amounts.receiptTotalTax);
            Console.WriteLine("Total: {0}", amounts.receiptTotalCost);
        }

        private void ValidationEvent(Item item)
        {

            //Do validation
            if (item.ItemQuantity <= 0)
                throw new Exception("Item Count Must be zero or greater");

            if (item.ItemShelfCost <= 0)
                throw new Exception("Item's must have a cost associated value");

            if (string.IsNullOrWhiteSpace(item.ItemName))
                throw new Exception("Item must have a name");

        }

        private void CollectionCalculationEvent()
        {
            //Calculate Total cost for collection
            CalcTotalCost();

            //Calculate Total tax for collection
            CalcSalesTax();
        }

        public void RemoveAt(int index)
        {
            ((IList<Item>)receiptList).RemoveAt(index);
        }

        public int IndexOf(Item item)
        {
            return ((IList<Item>)receiptList).IndexOf(item);
        }

        public void Insert(int index, Item item)
        {
            ValidationEvent(item);
            ((IList<Item>)receiptList).Insert(index, item);
            CollectionCalculationEvent();
        }

        public void Add(Item item)
        {
            ValidationEvent(item);
            ((IList<Item>)receiptList).Add(item);
            CollectionCalculationEvent();
        }

        public void Clear()
        {
            ((IList<Item>)receiptList).Clear();
        }

        public bool Contains(Item item)
        {
            return ((IList<Item>)receiptList).Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            ((IList<Item>)receiptList).CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            ValidationEvent(item);
            bool Value = ((IList<Item>)receiptList).Remove(item);
            CollectionCalculationEvent();
            return Value;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((IList<Item>)receiptList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Item>)receiptList).GetEnumerator();
        }
    }
}
