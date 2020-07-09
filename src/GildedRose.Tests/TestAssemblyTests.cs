using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests
{
    [TestClass]
    public class TestAssemblyTests
    {
        Program program = new Program();

        [TestMethod]
        public void OutputTest()
        {
            var program = new Program();
            program.Items = new List<Item>
                                    {
                                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                        new Item
                                            {
                                                Name = "Backstage passes to a TAFKAL80ETC concert",
                                                SellIn = 15,
                                                Quality = 20
                                            },
                                        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                    };
            program.UpdateQuality();

            foreach (var item in program.Items)
            {
                System.Console.WriteLine(item.Name + " Sellin " + item.SellIn + " Quality " + item.Quality);
            }
        }

        [TestMethod]
        public void MultipleUpdateQUalityx5()
        {

            program.Items = new List<Item>
                                {
                                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                    new Item
                                        {
                                            Name = "Backstage passes to a TAFKAL80ETC concert",
                                            SellIn = 15,
                                            Quality = 20
                                        },
                                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                };

            for (int i = 0; i < 50; i++)
            {
                program.UpdateQuality();

                foreach (var item in program.Items)
                {
                    System.Console.WriteLine(item.Name + " Sellin " + item.SellIn + " Quality " + item.Quality);
                }
                System.Console.WriteLine();
            }
        }
        [TestMethod]
        public void GivenItemSulfurasWhenUpdateQualityTheSellInAndQualitySame()
        {
            program.Items = new List<Item>
                                {
                                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}
                                };
            program.UpdateQuality();
            Assert.AreEqual(0, program.Items.First().SellIn);
            Assert.AreEqual(80, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenConjuredCakeWithPositiveSellInAndQuality_WhenUpdateQuality_ThenSellInDecrease1AndQualityDecrease1()
        {
            program.Items = new List<Item>
                                {
                                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                };

            program.UpdateQuality();

            Assert.AreEqual(2, program.Items.First().SellIn);
            Assert.AreEqual(5, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenConjuredCakeWithNegativeSellInAndQuality_WhenUpdateQuality_ThenSellInDecrease1AndQualityDecrease2()
        {
            program.Items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = -1, Quality = 6}
            };

            program.UpdateQuality();

            Assert.AreEqual(-2, program.Items.First().SellIn);
            Assert.AreEqual(4, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenConjuredCakeWithQuality0_WhenUpdateQuality_ThenQuality0()
        {
            program.Items = new List<Item>
            {
                new Item {Name = "Conjured Mana Cake", SellIn = -1000, Quality = 0}
            };

            program.UpdateQuality();

            Assert.AreEqual(0, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenAgedBrieWithSellinGreaterThan0_WhenUpdateQuality_ThenQualityIncreased1()
        {
            program.Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 50, Quality = 0}
            };

            program.UpdateQuality();

            Assert.AreEqual(1, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenAgedBrieWithSellinEqualOrLowerThan0_WhenUpdateQuality_ThenQualityIncreased2()
        {
            program.Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 2}
            };

            program.UpdateQuality();

            Assert.AreEqual(4, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenAgedBrieWithQualityGreaterOrEqualThan50_WhenUpdateQuality_ThenQualityIsTheSame()
        {
            program.Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 50}
            };

            program.UpdateQuality();

            Assert.AreEqual(50, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenElixirWithPositiveSellInAndQuality_WhenUpdateQuality_ThenSellInDecrease1AndQualityDecrease1()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
                                };

            program.UpdateQuality();

            Assert.AreEqual(4, program.Items.First().SellIn);
            Assert.AreEqual(6, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenElixirWithPositiveSellInAndQuality_WhenUpdateQuality_ThenSellInDecrease1AndQualityDecrease2()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 7}
                                };

            program.UpdateQuality();

            Assert.AreEqual(-1, program.Items.First().SellIn);
            Assert.AreEqual(5, program.Items.First().Quality);
        }
        [TestMethod]
        public void GivenElixirWithQuality0_WhenUpdateQuality_ThenQuality0()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 0}
                                };

            program.UpdateQuality();

            Assert.AreEqual(-1, program.Items.First().SellIn);
            Assert.AreEqual(0, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenDexterityWithPositiveSellInAndQuality_WhenUpdateQuality_ThenSellInDecrease1AndQualityDecrease1()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "+5 Dexterity Vest", SellIn = 5, Quality = 7}
                                };

            program.UpdateQuality();

            Assert.AreEqual(4, program.Items.First().SellIn);
            Assert.AreEqual(6, program.Items.First().Quality);
        }
        [TestMethod]
        public void GivenDexterityWithNegativeSellIn_WhenUpdateQuality_ThenSellInDecrease1AndQualityDecrease2()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "+5 Dexterity Vest", SellIn = -5, Quality = 7}
                                };

            program.UpdateQuality();

            Assert.AreEqual(-6, program.Items.First().SellIn);
            Assert.AreEqual(5, program.Items.First().Quality);
        }
        [TestMethod]
        public void GivenDexterityWithQualityZero_WhenUpdateQuality_ThenQUalityZero()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "+5 Dexterity Vest", SellIn = -5, Quality = 0}
                                };

            program.UpdateQuality();

            Assert.AreEqual(-6, program.Items.First().SellIn);
            Assert.AreEqual(0, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenConcertTicketSellinMajorThan10_WhenUpdateQuality_ThenQualityIncrease1()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20}
                                };

            program.UpdateQuality();

            Assert.AreEqual(14, program.Items.First().SellIn);
            Assert.AreEqual(21, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenConcertTicketSellinMinorThan10AndMajorThan5_WhenUpdateQuality_ThenQualityIncrease2()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 20}
                                };

            program.UpdateQuality();

            Assert.AreEqual(6, program.Items.First().SellIn);
            Assert.AreEqual(22, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenConcertTicketSellinMinorThan5AndMajorThan0_WhenUpdateQuality_ThenQualityIncrease3()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 20}
                                };

            program.UpdateQuality();

            Assert.AreEqual(3, program.Items.First().SellIn);
            Assert.AreEqual(23, program.Items.First().Quality);
        }

        [TestMethod]
        public void GivenConcertTicketSellinMinorThan0_WhenUpdateQuality_ThenQualityZero()
        {
            program.Items = new List<Item>
                                {
                                   new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20}
                                };

            program.UpdateQuality();

            Assert.AreEqual(-1, program.Items.First().SellIn);
            Assert.AreEqual(0, program.Items.First().Quality);
        }
    }
}