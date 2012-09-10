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
                ChangeDirectionAndImage(MobDirection.Left);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.D))
            {
                TryStep(Directions.Right, 4);
                ChangeDirectionAndImage(MobDirection.Right);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.W))
            {
                TryStep(Directions.Up, 4);
                ChangeDirectionAndImage(MobDirection.Up);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.S))
            {
                TryStep(Directions.Down, 4);
                ChangeDirectionAndImage(MobDirection.Down);
            }

            //Update camera:
            Camera.Position = Sprite.Position - new Vector2(WindowChecks.Width() / 2, WindowChecks.Height() / 2);

            //Pull out sword:
            if (KeyboardManager.PressedKeys.Contains(Keys.Space))
            {
                Vector2 mousePosNormal = new Vector2(MouseManager.CurrentMouseState.X - Sprite.Position.X, 
                    MouseManager.CurrentMouseState.Y - Sprite.Position.Y);
                mousePosNormal.Normalize();

                ObjectHolder.Create(new PlayerSword(this, (float)Math.Atan2(mousePosNormal.X, -mousePosNormal.Y)));
            }
        }
    }
}
