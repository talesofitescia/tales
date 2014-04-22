using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class DisplayComponent
    {
        public Texture2D Texture { get; set; }
        public bool Animate { get; set; }
        public int FrameRows { get; set; }
        public int FrameColumns { get; set; }
        public SpriteEffects Effect { get; set; }

        public DisplayComponent()
        {
            Animate = false;
            FrameRows = 1;
            FrameColumns = 2;
        }

    }
}
