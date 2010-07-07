using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ant.DB
{
    public class IDProvider
    {
        public int GetNewID(string key)
        {
            IDProviderItem item;
            if (!Items.TryGetValue(key, out item))
            {
                lock (_sync)
                {
                    if (!Items.TryGetValue(key, out item))
                    {
                        item = new IDProviderItem(key);
                        Items.Add(key, item);
                    }
                }
            }

            return item.GetNewID();
        }

        static IDProvider()
        {
            Items = new Dictionary<string, IDProviderItem>();
        }
        static Dictionary<string, IDProviderItem> Items;
        static readonly Object _sync = new object();

        class IDProviderItem
        {
            public IDProviderItem(string key)
            {
                Key = key;
            }
            private readonly Object _sync = new object();

            public string Key { get; set; }
            public int GetNewID()
            {
                int res = 1;
                lock (_sync)
                {
                    using (var s = new MongoSession())
                    {
                        var idItem = (from item in s.Query<IDItem>()
                                      where item.Key == Key
                                      select item).FirstOrDefault();

                        if (idItem == null)
                        {
                            idItem = new IDItem(Key);
                        }
                        res = idItem.Max + 1;
                        idItem.Max = res;
                        s.Upsert(idItem);
                    }
                }
                return res;
            }

        }

    }

    public class IDItem
    {
        public Object Id{get; set;}
        public int Max { get; set; }
        public string Key{ get; set; }

        public IDItem()
        { 
        }

        public IDItem(string key)
        {
            Max = 0;
            Key = key;
        }

    }
}
