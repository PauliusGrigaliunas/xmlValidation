using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XmlValidate
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("https://maitinimas.lt", @"C:\Users\Paulius\source\repos\XmlValidate\XmlValidate\XMLSchema.xsd");

            XDocument xmlDocument = XDocument.Load(@"C:\Users\Paulius\source\repos\XmlValidate\XmlValidate\Food.xml");
            bool validationErrors = false;

            xmlDocument.Validate(schema, (s, e) =>
            {
                Console.WriteLine(e.Message);
                validationErrors = true;
            });

            if (validationErrors)
            {
                Console.WriteLine("Validation failed");
            }
            else
            {
                Console.WriteLine("Validation succeeded");
            }
        }
    }
}
