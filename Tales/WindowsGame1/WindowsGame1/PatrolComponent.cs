using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class PatrolComponent
    {
        public int Offset { get; set; }
        public int MaxOffset { get; set; }
        public double LastUpdateMilliseconds { get; set; }
        public PatrolState State { get; set; }
        public PatrolState LastState { get; set; }
        public RangeOfViewComponent Range { get; set; }

        public PatrolComponent()
        {
            State = PatrolState.Up;
            Offset = 0;
        }
    }

    enum PatrolState
    {
        Up, Down, Left, Right, Wait
    }
}
