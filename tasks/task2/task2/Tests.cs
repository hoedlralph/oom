using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace task2
{
    [TestFixture]

    class Tests
    {
        [Test]
        public void CanCreateNotebook()
        {
            var x = new Notebook(100, 1024, "Nvidia", 100000);

            Assert.IsTrue(x.Graphic_card == "Nvidia");
            Assert.IsTrue(x.M_price == 100);
            Assert.IsTrue(x.Main_memory == 1024);
            Assert.IsTrue(x.Memory == 100000);
        }

        [Test]
        public void CannotCreateNotebookWithEmptyGraphic_card()
        {
            Assert.Catch(() =>
            {
                var x = new Notebook(100, 1024, "", 100000);
            });
        }

        [Test]
        public void CannotCreateNotebookWithnegprice()
        {
            Assert.Catch(() =>
            {
                var x = new Notebook(-100, 1024, "Nvidia", 100000);
            });
        }



        [Test]
        public void CanCreateServer()
        {
            var x = new Server(100000, 8, 128000, "Microsoft", "Oracle", 256000);

            Assert.IsTrue(x.Os == "Microsoft");
            Assert.IsTrue(x.Cores == 8);
            Assert.IsTrue(x.Main_memory == 128000);
            Assert.IsTrue(x.M_price == 100000);
        }

        [Test]
        public void CannotCreateServerWithoddcore()
        {
            Assert.Catch(() =>
            {
                var x = new Server(100000, 7, 128000, "Microsoft", "Oracle", 256000);
            });
        }

        [Test]
        public void CannotUpdateNotebookWithMainmemory()
        {
            

            Assert.Catch(() =>
            {
                var x = new Notebook(100, 1024, "Nvidia", 100000);
                x.main_mem(3333);
            });


        }

        [Test]
        public void CanUpdateNotebookWithMainmemory()
        {
            var x = new Notebook(100, 1024, "Nvidia", 100000);
            x.main_mem(2048);
            Assert.IsTrue(x.Main_memory == 2048);



        }

        [Test]
        public void CannotUpdateServerkWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new Server(100000, 8, 128000, "Microsoft", "Oracle", 256000);
                x.M_price = -50;
            });
        }

    }
}
