using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task2
{

    public interface IAsset
    {
        /// <summary>
        /// Gets a textual description of this item.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the item's price in the specified currency.
        /// </summary>
        string Asset_number(decimal numb);
    }



    public class Notebook : IAsset
    {
        private decimal m_price;
        private decimal main_memory;
        private string graphic_card;
        private decimal memory;


        public Notebook(decimal m_price, decimal main_memory, string graphic_card, decimal memory)
        {
           
            if (string.IsNullOrWhiteSpace(graphic_card)) throw new ArgumentException("keine Grafikkarte vorhanden", nameof(graphic_card));

            M_price = m_price;
            this.main_memory = main_memory;
            this.graphic_card = graphic_card;
            this.memory = memory;
        }

 
        public decimal M_price {



            get { return m_price; }
            set {
                    if (value < 0)
                    {
                         throw new Exception("Preis zu niedrig");
                    }
                m_price = value;
                        
                        
                }


        }


        public decimal Main_memory
        {

            get { return main_memory; }

        }


        public string Graphic_card { get { return graphic_card; } set { graphic_card = value; } }

        public decimal Memory { get { return memory; } set { memory = value; } }


        public void main_mem(decimal mem)
        {
            switch (mem)
            {
                case 1024:
                    main_memory = mem;
                    break;
                case 2048:
                    main_memory = mem;
                    break;
                case 4096:
                    main_memory = mem;
                    break;
                case 8192:
                    main_memory = mem;
                    break;
                default:
                    throw new Exception("ungültiger Wert");
                    

            }
        }


        #region IAsset implementation

        public string Description => "Notebook";

        public string Asset_number(decimal numb)
        {
            if (numb < 10000) throw new Exception("Inventarnummer zu niedrig");

            string help = "";
            help = System.Convert.ToString(numb);
            help += "N";
            return help;
        }

        #endregion
    }

    public class Server : IAsset
    {
        private decimal m_price;
        private decimal cores;
        private decimal main_memory;
        private string os;
        private string database;
        private decimal memory;


        public Server(decimal m_price, decimal cores ,decimal main_memory, string os, string database,decimal memory)
        {

            if (string.IsNullOrWhiteSpace(os)) throw new ArgumentException("kein Betriebssystem vorhanden", nameof(os));
            if (cores % 2 != 0) throw new Exception("ungerade Anzahl an Cores");
            
            M_price = m_price;
            this.main_memory = main_memory;
            this.os = os;
            this.database = database;
            this.cores = cores;
            this.memory = memory;
        }


        public decimal M_price
        {



            get { return m_price; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Preis zu niedrig");
                }
                m_price = value;


            }


        }


        public decimal Main_memory
        {

            get { return main_memory; }

        }
        public decimal Cores
        {

            get { return cores; }

        }


        public string Os { get { return os; } set { os = value; } }

        public decimal Memory { get { return memory; } set { memory = value; } }


        public void main_mem(decimal mem)
        {
            if (mem < 64000) throw new Exception("zu wenig Hauptspeicher");
            main_memory = mem;
        }

        #region IAsset implementation

        public string Description => "Server";

        public string Asset_number(decimal numb)
        {
            if (numb < 10000) throw new Exception("Inventarnummer zu niedrig");

            string help = "";
            help = System.Convert.ToString(numb);
            help += "S";
            return help;
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {

            try {
                    Notebook asus = new Notebook(100, 1024, "Nvidia", 100000);
                    Notebook sony = new Notebook(200, 2048, "ATI", 50000);
                    Notebook fujitsu = new Notebook(300, 4096, "MSI", 70000);
                    asus.main_mem(2048);
                     Console.WriteLine(asus.Memory);
                     asus.M_price = 200;
                     Console.WriteLine(asus.M_price);

                Server mic = new Server(100000, 8, 128000, "Microsoft", "Oracle", 256000);
                Server lin = new Server(50000, 4, 64000, "Linux", "DB2", 512000);
                var list1 = new List<IAsset> { asus, mic, lin };
                var list2 = new List<Notebook> { asus, sony, fujitsu };

                Serialization.Run(list2);

                /*
                decimal i = 0;
                
                foreach (IAsset s in list1)
                {
                    Console.WriteLine(s.Description);
                    Console.WriteLine(s.Asset_number(12000+i));
                    i++;
                }

                  */
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            


        }
    }
}
