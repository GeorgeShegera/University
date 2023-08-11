using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib;

namespace University.Structs
{
    internal struct KeyValueEntry<T, K>
    {
        public K id;
        public T value;
        public KeyValueEntry(K id, T value)
        {
            this.id = id;
            this.value = value;
        }
    }
}
