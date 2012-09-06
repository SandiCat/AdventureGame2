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
        public Accesory(Mob mob)
            : base()
        {
            AssingedMob = mob;
            UpdateWithMovable();
        }

        public Mob AssingedMob { get; private set; }
        private Vector2 _mobCentar
        {
            get
            {
                float x = AssingedMob.Sprite.GetTopLeftCorner().X + AssingedMob.Sprite.Image.Width / 2;
                float y = AssingedMob.Sprite.GetTopLeftCorner().Y + AssingedMob.Sprite.Image.Height / 2;
                return new Vector2(x, y);
            }
            set
            {
                _mobCentar = value;
            }
        }

        protected override void Update()
        {
            UpdateWithMovable();
        }

        private void UpdateWithMovable()
        {
            //Calculate direction:

            if (AssingedMob.Direction == MobDirection.Up)
            {
                Sprite.Rotation = Directions.Up;
            }
            else if (AssingedMob.Direction == MobDirection.Down)
            {
                Sprite.Rotation = Directions.Down;
            }
            else if (AssingedMob.Direction == MobDirection.Left)
            {
                Sprite.Rotation = Directions.Left;
            }
            else if (AssingedMob.Direction == MobDirection.Right)
            {
                Sprite.Rotation = Directions.Right;
            }

            //Transform rotation into direction:
            Vector2 up = new Vector2(0, -1);
            Matrix rotationMat = Matrix.CreateRotationZ(Sprite.Rotation);
            Vector2 direction = Vector2.Transform(up, rotationMat);

            //Move to mob:
            Sprite.Position = _mobCentar + direction * (Grid.SquareSide / 2 + Sprite.Image.Height);
        }
    }
}