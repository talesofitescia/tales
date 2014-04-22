using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class AnimationNode : Node
    {
        public DisplayComponent display { get; set; }
        public PositionComponent position { get; set; }
    }
}
