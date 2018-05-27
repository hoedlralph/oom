using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace task2
{
    class Serialization
    {
        public static void Run(List<Notebook> items)
        {
            var notebook = items[0];


            Console.WriteLine(JsonConvert.SerializeObject(notebook));


            Console.WriteLine(JsonConvert.SerializeObject(notebook, Formatting.Indented));

            // 3. serialize all items
            // ... include type, so we can deserialize sub-classes to interface type
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            // 4. store json string to file "items.json" on your Desktop
            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            // 5. deserialize items from "items.json"
            // ... and print Description and attributes of deserialized items
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<Notebook[]>(textFromFile, settings);
            foreach (var x in itemsFromFile) Console.WriteLine($"{x.Main_memory} {x.Graphic_card} {x.M_price}");
        }




    }
}
