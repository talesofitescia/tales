using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class RenderNode : Node
    {
        public PositionComponent position { get; set; }
        public DisplayComponent display { get; set; }
    }
}
