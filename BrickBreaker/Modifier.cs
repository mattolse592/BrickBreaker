using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Modifier
    {
        public String mod;
        public int effCount;

        public Modifier()
        {
            mod = "";
            effCount = 0;
        }

        public Modifier(String _mod)
        {
            mod = _mod;
            effCount = 0;
        }

        public Modifier(String _mod, int time)
        {
            mod = _mod;
            effCount = time;
        }
    }
}
