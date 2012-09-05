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
        public Accesory(MovingObject movable, float rotation)
            : base()
        {
            Sprite.Rotation = rotation;
            Movable = movable;
            MoveToMovable();
        }

        public MovingObject Movable { get; private set; }
        private Vector2 _movableCentar
        {
            get
            {
                float x = Movable.Sprite.GetTopLeftCorner().X + Movable.Sprite.Image.Width / 2;
                float y = Movable.Sprite.GetTopLeftCorner().Y + Movable.Sprite.Image.Height / 2;
                return new Vector2(x, y);
            }
            set
            {
                _movableCentar = value;
            }
        }

        protected override void Update()
        {
            MoveToMovable();
        }

        private void MoveToMovable()
        {
            Vector2 up = new Vector2(0, -1);
            Matrix rotationMat = Matrix.CreateRotationZ(Sprite.Rotation);
            Vector2 direction = Vector2.Transform(up, rotationMat);

            Sprite.Position = _movableCentar + direction * 50;
        }
    }
}