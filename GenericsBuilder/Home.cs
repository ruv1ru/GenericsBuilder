using System;

namespace GenericsBuilder
{
    class Home : IComparable<Home>
    {
        public Home()
        {
        }
        public int Area{get;set;}

        public int CompareTo(Home other)
        {
            if(other.Area == this.Area) return 0;
            if(other.Area > this.Area) return -1;
            return 1;

        }
    }

}
