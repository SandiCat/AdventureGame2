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
    
    public enum Side
    {
        Up, Down, Left, Right
    }

    public abstract class Accesory : GameObject
    {
        public Accesory()
            : base()
        {
        }
        public Accesory(Vector2 position)
            : base(position)
        {
        }
        public Accesory(MovingObject movable, Side side)
            : base()
        {
            side = _side;
            
            if (side == Side.Down)
            {
                Sprite.Rotation = Directions.Down;
            }
            else if (side == Side.Right)
            {
                Sprite.Rotation = Directions.Right;
            }
            else if (side == Side.Left)
            {
                Sprite.Rotation = Directions.Left;
            }

            _movable = movable;
        }

        private MovingObject _movable;

        private readonly Side _side;

        protected override void Update()
        {
            Rectangle _rectangleMov = _movable.Sprite.GetRectangle();
            Rectangle _rectangleThis = Sprite.GetRectangle();

            if (_side == Side.Up)
            {
                int x = _rectangleMov.Right - _rectangleThis.Width;
                int y = _rectangleMov.Top - _rectangleThis.Height;
                Sprite.Position = new Vector2(x, y);
            }
            else if (_side == Side.Down)
            {
                int x = _rectangleMov.Left;
                int y = _rectangleMov.Bottom;
                Sprite.Position = new Vector2(x, y);
            }
            else if (_side == Side.Right)
            {
                int x = _rectangleMov.Right;
                int y = _rectangleMov.Bottom - _rectangleThis.Height;
                Sprite.Position = new Vector2(x, y);
            }
            else if (_side == Side.Left)
            {
                int x = _rectangleMov.Left - _rectangleThis.Width;
                int y = _rectangleMov.Top;
                Sprite.Position = new Vector2(x, y);
            }
        }
    }
}