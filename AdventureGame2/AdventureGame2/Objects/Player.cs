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
        private enum PlayerDirection
        {
            Up, Down, Left, Right
        }

        PlayerDirection Direction = PlayerDirection.Right;

        static public Texture2D TextureUp;
        static public Texture2D TextureDown;
        static public Texture2D TextureLeft;
        static public Texture2D TextureRight;

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
                Direction = PlayerDirection.Left;
                Sprite.Image = TextureLeft;
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.D))
            {
                TryStep(Directions.Right, 4);
                Direction = PlayerDirection.Right;
                Sprite.Image = TextureRight;
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.W))
            {
                TryStep(Directions.Up, 4);
                Direction = PlayerDirection.Up;
                Sprite.Image = TextureUp;
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.S))
            {
                TryStep(Directions.Down, 4);
                Direction = PlayerDirection.Down;
                Sprite.Image = TextureDown;
            }

            //Change direction and image:
            if (KeyboardManager.PressedKeys.Contains(Keys.A))
            {
                Direction = PlayerDirection.Left;
                Sprite.Image = TextureLeft;
            }
            else if (KeyboardManager.PressedKeys.Contains(Keys.D))
            {
                Direction = PlayerDirection.Right;
                Sprite.Image = TextureRight;
            }
            else if (KeyboardManager.PressedKeys.Contains(Keys.W))
            {
                Direction = PlayerDirection.Up;
                Sprite.Image = TextureUp;
            }
            else if (KeyboardManager.PressedKeys.Contains(Keys.S))
            {
                Direction = PlayerDirection.Down;
                Sprite.Image = TextureDown;
            }

            //Update camera:
            Camera.Position = Sprite.Position - new Vector2(WindowChecks.Width() / 2, WindowChecks.Height() / 2);

            if (KeyboardManager.PressedKeys.Contains(Keys.Space))
            {
                //Delete any existing accesories:
                List<GameObject> ToDelete = new List<GameObject>();
                foreach (var obj in ObjectHolder.Objects.Where((obj) => obj is Accesory)) { ToDelete.Add(obj); }
                foreach (var obj in ToDelete) { ObjectHolder.Delete(obj);  }

                if (Direction == PlayerDirection.Up)
                {
                    ObjectHolder.Create(new PlayerSword(this, Side.Up));
                }
                else if (Direction == PlayerDirection.Down)
                {
                    ObjectHolder.Create(new PlayerSword(this, Side.Down));
                }
                else if (Direction == PlayerDirection.Left)
                {
                    ObjectHolder.Create(new PlayerSword(this, Side.Left));
                }
                else if (Direction == PlayerDirection.Right)
                {
                    ObjectHolder.Create(new PlayerSword(this, Side.Right));
                }
            }
        }
    }
}
