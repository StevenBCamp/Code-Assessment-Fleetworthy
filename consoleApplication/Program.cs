using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codeAssessmentLibrary.Collections;
using codeAssessmentLibrary.Models;

namespace consoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input One
            var ReceiptList = new ReceiptCollection
            {
                new Item(12.49M, "book", new Tax(false, false), 1),
                new Item(14.99M, "music CD", new Tax(true, false), 1),
                new Item(0.85M, "chocolate bar", new Tax(false, false), 1)
            };

            ReceiptList.Display();
            ReceiptList.Clear();
            Console.ReadLine();

            // Input Two
            ReceiptList = new ReceiptCollection
            {
                new Item(10.00M, "imported box of chocolates", new Tax(false, true), 1),
                new Item(47.50M, "imported bottle of perfume", new Tax(true, true), 1)
            };

            ReceiptList.Display();
            ReceiptList.Clear();
            Console.ReadLine();

            // Input Three
            ReceiptList = new ReceiptCollection
            {
            new Item(27.99M, "imported bottle of perfume", new Tax(true, true), 1),
            new Item(18.99M, "bottle of perfume", new Tax(true, false), 1),
            new Item(9.75M, "packet of headache pills", new Tax(false, false), 1),
            new Item(11.25M, "box of imported chocolates", new Tax(false, true), 1)
            };

            ReceiptList.Display();
            ReceiptList.Clear();
            Console.ReadLine();

        }
    }
}
