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
    public enum MobDirection
    {
        Up, Down, Left, Right
    }

    public abstract class Mob : MovingObject
    {

        public Mob()
            : base()
        {
            Direction = MobDirection.Right;
        }
        public Mob(Vector2 position)
            : base(position)
        {
        }
        public Mob(Vector2 position, MobDirection direction)
            : base(position)
        {
            Direction = direction;
        }


        public MobDirection Direction = MobDirection.Right;

        static public Texture2D TextureUp;
        static public Texture2D TextureDown;
        static public Texture2D TextureLeft;
        static public Texture2D TextureRight;

        protected override void Update()
        {
            
        }

        protected void ChangeDirectionAndImage(MobDirection direction)
        {
            Direction = direction;

            if (direction == MobDirection.Up)
            {
                Sprite.Image = TextureUp;
            }
            else if (direction == MobDirection.Down)
            {
                Sprite.Image = TextureDown;
            }
            else if (direction == MobDirection.Left)
            {
                Sprite.Image = TextureLeft;
            }
            else if (direction == MobDirection.Right)
            {
                Sprite.Image = TextureRight;
            }
        }
    }
}
