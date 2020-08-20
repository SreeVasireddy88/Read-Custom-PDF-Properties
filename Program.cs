using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCustomPropertiesFromPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfFilePath = @"C:\Temp\JSReport\Guardian_SSA_SrirajVasireddy_05292020123532.pdf";
            string propertyName = "Client Name";
            string propertyValue = GetPropertyByName(pdfFilePath, propertyName);

            if (propertyValue == null)
            {
                Console.WriteLine("Property " + propertyName + " was not found.");
            }
            else
            {
                Console.WriteLine(propertyName + " = " + propertyValue);
            }
        }

        static string GetPropertyByName(string filePath, string propertyName)
        {
            if (String.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath) || String.IsNullOrEmpty(propertyName)) { return null; }
            Dictionary<string, string> propertyInfo = GetPdfProperties(filePath);
            foreach (KeyValuePair<string, string> property in propertyInfo)
            {
                if (property.Key == propertyName) { return property.Value; }
            }
            return null;
        }

        static Dictionary<string, string> GetPdfProperties(string filePath)
        {
            Dictionary<string, string> propertyInfo = null;

            using (PdfReader reader = new PdfReader(filePath))
            {
                propertyInfo = reader.Info;
                reader.Close();
            }

            return propertyInfo;
        }
    }
}
