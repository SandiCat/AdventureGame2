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


namespace AdventureGameNamespace
{
    public class PlayerSword : Accesory
    {
        public PlayerSword()
            : base()
        {
        }
        public PlayerSword(Vector2 position)
            : base(position)
        {
        }
        public PlayerSword(MovingObject movable, Side side)
            : base(movable, side)
        {
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}