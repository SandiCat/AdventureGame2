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
    public class Player : Mob
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
            //Move:
            if (KeyboardManager.KeysDown.Contains(Keys.A))
            {
                TryStep(Directions.Left, 4);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.D))
            {
                TryStep(Directions.Right, 4);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.W))
            {
                TryStep(Directions.Up, 4);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.S))
            {
                TryStep(Directions.Down, 4);
            }

            //Change direction and image:
            if (KeyboardManager.PressedKeys.Contains(Keys.A))
            {
                ChangeDirectionAndImage(MobDirection.Left);
            }
            else if (KeyboardManager.PressedKeys.Contains(Keys.D))
            {
                ChangeDirectionAndImage(MobDirection.Right);
            }
            else if (KeyboardManager.PressedKeys.Contains(Keys.W))
            {
                ChangeDirectionAndImage(MobDirection.Up);
            }
            else if (KeyboardManager.PressedKeys.Contains(Keys.S))
            {
                ChangeDirectionAndImage(MobDirection.Down);
            }

            //Update camera:
            Camera.Position = Sprite.Position - new Vector2(WindowChecks.Width() / 2, WindowChecks.Height() / 2);

            //Pull out sword:
            if (KeyboardManager.PressedKeys.Contains(Keys.Space))
            {
                ObjectHolder.Create(new PlayerSword(this));
            }
        }
    }
}
