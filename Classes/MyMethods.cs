using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace A_to_Z_Antique_Shop
{
    internal class MyMethods
    { 
        internal static ObservableCollection<items> GenerateItems()
        {
            List<items> items = items_Storage.ReadXml<List<items>>("items.xml");
            var lst = new ObservableCollection<items>();
            foreach (var p in items)
            {

                var itm = (new items
                {
                    ItemName = p.ItemName,
                    yearofmade = p.yearofmade,
                    Category = p.Category,
                    descreption = p.descreption,
                    price = p.price,
                    imagePath = p.imagePath
                });

                lst.Add(itm);
            }

            return lst;
        }
    }
}