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
    public class Player : MovingObject
    {
        public Player()
            : base()
        {
        }
        public Player(Vector2 position)
            : base(position)
        {
        }

        protected override void Update()
        {
            //StepingAngle:
            if (KeyboardManager.KeysDown.Contains(Keys.A))
                TryStep(Directions.Left, 4);
            else if (KeyboardManager.KeysDown.Contains(Keys.D))
                TryStep(Directions.Right, 4);
            else if (KeyboardManager.KeysDown.Contains(Keys.W))
                TryStep(Directions.Up, 4);
            else if (KeyboardManager.KeysDown.Contains(Keys.S))
                TryStep(Directions.Down, 4);
        }
    }
}
