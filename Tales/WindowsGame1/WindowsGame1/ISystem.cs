using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    interface ISystem
    {
        void update(GameTime gameTime);
    }

    enum Systems
    {
        InputSystem,
        RenderSystem
    }
}
