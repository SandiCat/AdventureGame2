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
            TurnRandomDirection();
        }
        public CannonBot(Vector2 position)
            : base(position)
        {
            TurnRandomDirection();
        }

        const int _changeDirection_top = 120;
        const int _changeDirection_bottom = 60;
        Alarm _changeDirection = new Alarm(new Random().Next(_changeDirection_bottom, _changeDirection_top));

        const int speed = 2;

        protected override void Update()
        {
            //Move:
            StepAvoidingWalls(Direction);

            if (_changeDirection.IsDone())
            {
                TurnRandomDirection();
                _changeDirection.Restart(new Random().Next(_changeDirection_bottom, _changeDirection_top));
            }

            if (this.IsColliding(typeof(PlayerSword)))
            {
                ObjectHolder.Delete(this);
            }
        }

        private bool CanStep(MobDirection direction, int distance)
        {
            float angle = MobDirectionToAngle(direction);

            StepAngle(angle, distance);

            bool ranIntoWall = false;
            List<GameObject> solids = ObjectHolder.Objects.Where(obj => obj is SolidObject || obj is MovingObject).ToList();
            foreach (var solid in solids)
            {
                if (this.IsRectangleColliding(solid))
                {
                    ranIntoWall = true;
                    break;
                }
            }

            StepAngle(angle, -distance);

            return !ranIntoWall;
        }
        private void TurnRandomDirection()
        {
            MobDirection direction = (MobDirection) Randomizer.Rnd.Next(0, 5);
            ChangeDirectionAndImage(direction);
        }
        private void StepAvoidingWalls(MobDirection direction)
        {
            if (CanStep(direction, speed))
            {
                float angle = MobDirectionToAngle(direction);

                StepAngle(angle, speed);
            }
            else
            {
                TurnRandomDirection();
            }
        }
    }
}
