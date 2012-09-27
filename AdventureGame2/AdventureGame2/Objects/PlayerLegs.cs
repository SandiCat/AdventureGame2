using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Wormhole;

namespace MazeGameEngine
{
    public class PlayerLegs : Legs
    {
        public PlayerLegs()
            : base()
        {
        }
        public PlayerLegs(Vector2 position)
            : base(position)
        {
        }
        public PlayerLegs(Vector2 position, MobDirection direction)
            : base(position, direction)
        {
        }
        public PlayerLegs(Human human)
            : base(human)
        {
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
