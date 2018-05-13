using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task2
{
    public class Notebook
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
    }



    class Program
    {
        static void Main(string[] args)
        {

            try {
                    Notebook asus = new Notebook(100, 1024, "Nvidia", 100000);
                    asus.main_mem(2048);
                     Console.WriteLine(asus.Memory);
                     asus.M_price = 200;
                     Console.WriteLine(asus.M_price);

            }catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }
    }
}
