using BandApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BandApp.Utils
{
    public static class XmlHandler
    {
        private static readonly Type[] KnownTypes = { typeof(Member), typeof(Leader) };

        public static List<BandMember> LoadFromFile(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<BandMember>), KnownTypes);
                using (var reader = new StreamReader(filePath))
                {
                    var members = (List<BandMember>)serializer.Deserialize(reader);
                    Console.WriteLine($"File loaded successfully: {filePath}");
                    return members;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading file: {filePath}\nError Message: {ex.Message}\nStack Trace: {ex.StackTrace}");
                return new List<BandMember>(); 
            }
        }

        public static void SaveToFile(string filePath, List<BandMember> data)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<BandMember>), KnownTypes);
                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, data);
                    Console.WriteLine($"File saved successfully: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving file: {filePath}\nError Message: {ex.Message}\nStack Trace: {ex.StackTrace}");
            }
        }
    }
}
