using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLocal
{
    public abstract class BoardField
    {
        public abstract override string ToString();
        public abstract Boolean PlayerIsHere { get; set; }
        public abstract Boolean BoxIsHere { get; set; }
        public abstract Boolean IsGoalField { get; set; }
        public abstract Boolean IsWallField { get; set; }
    }
}
