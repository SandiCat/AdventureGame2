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
    public class Player : Human
    {
        public Player()
            : base()
        {
            _legs = new PlayerLegs(this);
            ObjectHolder.Create(_legs);
        }
        public Player(Vector2 position)
            : base(position)
        {
            _legs = new PlayerLegs(this);
            ObjectHolder.Create(_legs);
        }

        bool _canSword = true;
        Alarm _restart_canSword = new Alarm();

        const int _speed = 4;

        protected override void Update()
        {
            _legs.Walking = true;

            //Move:
            if (KeyboardManager.KeysDown.Contains(Keys.A))
            {
                TryStep(Directions.Left, _speed);
                ChangeDirectionAndImage(MobDirection.Left);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.D))
            {
                TryStep(Directions.Right, _speed);
                ChangeDirectionAndImage(MobDirection.Right);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.W))
            {
                TryStep(Directions.Up, _speed);
                ChangeDirectionAndImage(MobDirection.Up);
            }
            else if (KeyboardManager.KeysDown.Contains(Keys.S))
            {
                TryStep(Directions.Down, _speed);
                ChangeDirectionAndImage(MobDirection.Down);
            }
            else
            {
                _legs.Walking = false;
            }

            //Update camera:
            Camera.Position = Sprite.Position - new Vector2(WindowChecks.Width() / 2, WindowChecks.Height() / 2);

            //Pull out sword:
            if (MouseManager.Click() && _canSword != false)
            {
                Vector2 mousePosNormal = new Vector2(MouseManager.CurrentMouseState.X,
                    MouseManager.CurrentMouseState.Y);
                mousePosNormal -= Sprite.Position - Camera.Position;

                ObjectHolder.Create(new PlayerSword(this, (float)Math.Atan2(mousePosNormal.X, -mousePosNormal.Y)));

                _canSword = false;
                _restart_canSword.Restart(30);
            }

            //Restart _canSword:
            if (_restart_canSword.IsDone())
            {
                _canSword = true;
            }
        }
    }
}
