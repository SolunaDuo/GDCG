using System.Collections;
using System.Collections.Generic;

namespace Tools
{
    namespace Tuple
    {
        public class Tuple<_Type1, _Type2>
        {
            public _Type1 first { get; private set; }
            public _Type2 second { get; private set; }
            internal Tuple( _Type1 fst, _Type2 scd )
            {
                first = fst;
                second = scd;
            }
        }

        public class Tuple<_Type1, _Type2, _Type3>
        {
            public _Type1 first { get; private set; }
            public _Type2 second { get; private set; }
            public _Type3 third { get; private set; }
            internal Tuple( _Type1 fst, _Type2 scd, _Type3 trd )
            {
                first = fst;
                second = scd;
                third = trd;
            }
        }

        public static class Tuple
        {
            public static Tuple<_Type1, _Type2> Create<_Type1, _Type2>( _Type1 fst, _Type2 scd )
            {
                var tuple = new Tuple<_Type1, _Type2>( fst, scd );
                return tuple;
            }

            public static Tuple<_Type1, _Type2, _Type3> Create<_Type1, _Type2, _Type3>( _Type1 fst, _Type2 scd, _Type3 trd )
            {
                var tuple = new Tuple<_Type1, _Type2, _Type3>( fst, scd, trd );
                return tuple;
            }
        }

    }
}
