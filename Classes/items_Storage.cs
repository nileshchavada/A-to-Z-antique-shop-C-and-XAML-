using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;


namespace A_to_Z_Antique_Shop
{
    internal class items_Storage
    {
    
        internal static void WriteXml(ObservableCollection<items> items, string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<items>));
            FileStream fs;
            fs = new FileStream(file, FileMode.Create);
            xs.Serialize(fs, items);
            fs.Close();
        }

        internal static ObservableCollection<items> ReadXml(string file)
        {

            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<items>));

                    return (ObservableCollection<items>)xs.Deserialize(sr);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
                throw;
            }
        }

        internal static T ReadXml<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));

                    return (T)xs.Deserialize(sr);
                }
            }
            catch (Exception)
            {

                return default(T);
            }
        }

        
    }

}
