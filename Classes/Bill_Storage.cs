using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;


namespace A_to_Z_Antique_Shop
{
    internal class Bill_Storage
    {

        internal static void WriteXml(ObservableCollection<Bill> Bill, string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Bill>));
            FileStream fs;
            fs = new FileStream(file, FileMode.Create);
            xs.Serialize(fs, Bill);
            fs.Close();
        }

        internal static ObservableCollection<Bill> ReadXml(string file)
        {

            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Bill>));

                    return (ObservableCollection<Bill>)xs.Deserialize(sr);
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
