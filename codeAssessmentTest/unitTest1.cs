using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using codeAssessmentLibrary.Collections;
using codeAssessmentLibrary.Models;

namespace codeAssessmentTest
{
    [TestClass]
    public class UnitTest1
    {
        #region Input and Output
        [TestMethod, TestCategory("Daily"), TestCategory("InputOne")]
        public void InputOne()
        {
            //1 book at 12.49
            //1 music CD at 14.99
            //1 chocolate bar at 0.85

            var ReceiptList = new ReceiptCollection
            {
                new Item(12.49M, "book", new Tax(false, false), 1),
                new Item(14.99M, "music CD", new Tax(true, false), 1),
                new Item(0.85M, "chocolate bar", new Tax(false, false), 1)
            };

            var Amount = new ReceiptCosts { receiptTotalCost = 29.83M, receiptTotalTax = 1.50M };
            Assert.AreEqual(3, ReceiptList.Count);
            Assert.AreEqual(Amount.receiptTotalCost, ReceiptList.amounts.receiptTotalCost);
            Assert.AreEqual(Amount.receiptTotalTax, ReceiptList.amounts.receiptTotalTax);


            //1 book: 12.49
            //1 music CD: 16.49
            //1 chocolate bar: 0.85
            //Sales Taxes: 1.50
            //Total: 29.83
        }

        [TestMethod, TestCategory("Daily"), TestCategory("InputTwo")]
        public void InputTwo()
        {
            //Input 2:
            //1 imported box of chocolates at 10.00
            //1 imported bottle of perfume at 47.50

            var ReceiptList = new ReceiptCollection
            {
                new Item(10.00M, "imported box of chocolates", new Tax(false, true), 1),
                new Item(47.50M, "imported bottle of perfume", new Tax(true, true), 1)
            };

            var Amount = new ReceiptCosts { receiptTotalCost = 65.15M, receiptTotalTax = 7.65M };
            Assert.AreEqual(2, ReceiptList.Count);
            Assert.AreEqual(Amount.receiptTotalCost, ReceiptList.amounts.receiptTotalCost);
            Assert.AreEqual(Amount.receiptTotalTax, ReceiptList.amounts.receiptTotalTax);

            //1 imported box of chocolates: 10.50
            //1 imported bottle of perfume: 54.65
            //Sales Taxes: 7.65
            //Total: 65.15
        }

        [TestMethod, TestCategory("Daily"), TestCategory("InputThree")]
        public void InputThree()
        {
            //Input 3:
            //1 imported bottle of perfume at 27.99
            //1 bottle of perfume at 18.99
            //1 packet of headache pills at 9.75
            //1 box of imported chocolates at 11.25

            var ReceiptList = new ReceiptCollection
            {
                new Item(27.99M, "imported bottle of perfume", new Tax(true, true), 1),
                new Item(18.99M, "bottle of perfume", new Tax(true, false), 1),
                new Item(9.75M, "packet of headache pills", new Tax(false, false), 1),
                new Item(11.25M, "box of imported chocolates", new Tax(false, true), 1)
            };

            var Amount = new ReceiptCosts { receiptTotalCost = 74.68M, receiptTotalTax = 6.70M };
            Assert.AreEqual(4, ReceiptList.Count);
            Assert.AreEqual(Amount.receiptTotalCost, ReceiptList.amounts.receiptTotalCost);
            Assert.AreEqual(Amount.receiptTotalTax, ReceiptList.amounts.receiptTotalTax);


            //Output 3:
            //1 imported bottle of perfume: 32.19
            //1 bottle of perfume: 20.89
            //1 packet of headache pills: 9.75
            //1 imported box of chocolates: 11.85
            //Sales Taxes: 6.70
            //Total: 74.68
        }
        #endregion

        #region Negative Test Case / Expected to error
        [TestMethod, TestCategory("Daily"), TestCategory("NegativeTestCases")]
        public void CheckInputValuesNullName()
        {
            //Items in the reciept should not exists without names
            try
            {
                var ReceiptList = new ReceiptCollection
                {
                    new Item(27.99M, null, new Tax(true, true), 1)
                };
                Assert.Fail();
            } 
            catch(Exception ex)
            {
                
            }

        }

        [TestMethod, TestCategory("Daily"), TestCategory("NegativeTestCases")]
        public void CheckInputValuesItemQuantity()
        {
            //Items should alwas have quantities.
            try
            {
                var ReceiptList = new ReceiptCollection
                {
                    new Item(27.99M, "imported bottle of perfume", new Tax(true, true), 0)
                };
                Assert.Fail();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod, TestCategory("Daily"), TestCategory("NegativeTestCases")]
        public void CheckInputValuesShelfCost()
        {
            //Items should alwas have quantities.
            try
            {
                var ReceiptList = new ReceiptCollection
                {
                    new Item(0M, "imported bottle of perfume", new Tax(true, true), 1)
                };
                Assert.Fail();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Test Internals
        [TestMethod, TestCategory("Daily"), TestCategory("LibraryInternalChecks")]
        public void CheckInternals()
        {
            Tax TaxObj = new Tax(true, false);
            var ShelfCost = 1.0M;

            Assert.AreEqual(0M, TaxObj.CalcImportTax(ShelfCost));
            Assert.AreEqual(0.1M, TaxObj.CalcSalesTax(ShelfCost));
        }
        #endregion
    }
}
