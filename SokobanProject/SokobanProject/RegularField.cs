using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanLocal
{
    class RegularField : BoardField
    {
        public RegularField(Boolean PlayerIsHere, Boolean BoxIsHere)
        {
            this.PlayerIsHere = PlayerIsHere;
            this.BoxIsHere = BoxIsHere;
        }
        public RegularField()
        {
            this.PlayerIsHere = false;
            this.BoxIsHere = false;
        }
        public override Boolean PlayerIsHere { get; set; } = false;
        public override Boolean BoxIsHere { get; set; } = false;
        public override Boolean IsGoalField { get; set; } = false;
        public override Boolean IsWallField { get; set; } = false;
        public override string ToString()
        {
            if (PlayerIsHere)
            {
                return "[ P ]";
            }
            else if (BoxIsHere)
            {
                return "[ X ]";
            }
            else if (IsGoalField)
            {
                return "[ G ]";
            }
            else if (IsWallField)
            {
                return "[ W ]";
            }
            else
            {
                return "[   ]";
            }
        }
    }
}
