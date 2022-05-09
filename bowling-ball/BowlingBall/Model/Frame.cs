using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall.Model
{
    public class Frame
    {
        public int FrameID { get; set; }
        public int Roll1 { get; set; }
        public int Roll2 { get; set; }
        public int Extraroll { get; set; }
        public int Score { get; set; }
    }
}
