using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolTable.Helper
{
    class SymbolTable<Key, Value> where Key : IComparable<Key>
                                  where Value: IComparable<Value>
    {
        private SortedDictionary<Key, Value> st; 
        public SymbolTable()
        {
            st = new SortedDictionary<Key, Value>();
        }

        public Value Get(Key key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
            return st.GetValueOrDefault(key);
        }

        public void Put(Key key, Value value)
        {
            if (key == null) throw new ArgumentNullException();
            if (value == null) st.Remove(key);
            else st.Add(key, value);
        }

        public void Remove(Key key)
        {
            if (key == null) throw new ArgumentNullException();
            st.Remove(key);
        }

        public int size()
        {
            return st.Count();
        }

        public bool isEmpty()
        {
            return st.Count() == 0;
        }

        public Key[] keys()
        {
            return st.Keys.ToArray();
        }
    }
}
