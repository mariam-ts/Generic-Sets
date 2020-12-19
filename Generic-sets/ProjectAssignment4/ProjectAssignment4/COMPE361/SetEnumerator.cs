
using System;
using System.Collections.Generic;
using System.Collections;

namespace ProjectAssignment4.COMPE361
{
    // in this class I am defining IEnumerator
    public class SetEnumerator<T> : IEnumerator<Set<T>>
    {
        private Set<T> _set;
        private int _indx;

        //constructor
        public SetEnumerator(Set<T> set)
        {
            _set = set;
            _indx = -1;
        }

        public Set<T> Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        // if there is another member after index returns true if not returns false
        public bool MoveNext()
        {
            return ++_indx < _set.Count;
        }
        // resets index
        public void Reset()
        {
            _indx = -1;
        }
    }


}

