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
using MazeGameEngine;


namespace AdventureGameNamespace
{
    public class CannonBot : Mob
    {
        public CannonBot()
            : base()
        {
        }
        public CannonBot(Vector2 position)
            : base(position)
        {
        }

        protected override void Update()
        {
        }
    }
}
