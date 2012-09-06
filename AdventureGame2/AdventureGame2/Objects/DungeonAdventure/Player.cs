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

        Alarm _swordAlarm = new Alarm();
        Alarm _reset_PullOutSword = new Alarm();
        bool _canPullOutSword = true;

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

            ManageAccesores();
        }

        private void ManageAccesores()
        {
            #region Sword
            //Make the sword appear:
            if (KeyboardManager.PressedKeys.Contains(Keys.Space) && _canPullOutSword)
            {
                //Delete any existing Player Swords:
                List<GameObject> ToDelete = new List<GameObject>();
                foreach (var obj in ObjectHolder.Objects.Where((obj) => obj.GetType() == typeof(PlayerSword))) { ToDelete.Add(obj); }
                foreach (var obj in ToDelete) { ObjectHolder.Delete(obj); }

                if (Direction == MobDirection.Up)
                {
                    ObjectHolder.Create(new PlayerSword(this, Directions.Up));
                }
                else if (Direction == MobDirection.Down)
                {
                    ObjectHolder.Create(new PlayerSword(this, Directions.Down));
                }
                else if (Direction == MobDirection.Left)
                {
                    ObjectHolder.Create(new PlayerSword(this, Directions.Left));
                }
                else if (Direction == MobDirection.Right)
                {
                    ObjectHolder.Create(new PlayerSword(this, Directions.Right));
                }

                _swordAlarm.Restart(10);

                _canPullOutSword = false;
                _reset_PullOutSword.Restart(40);
            }

            //Delete the sword when alarm is over:
            if (_swordAlarm.IsDone())
            {
                PlayerSword sword = (PlayerSword)ObjectHolder.Objects.Where((obj) => obj.GetType() == typeof(PlayerSword)).ToList()[0];

                ObjectHolder.Delete(sword);
            }

            //Restart reset _canPullOutSword:
            if (_reset_PullOutSword.IsDone())
            {
                _canPullOutSword = true;
            }
            #endregion

            #region Update
            //Update all accesories attached to this:
            List<GameObject> accesories = ObjectHolder.Objects.Where((obj) => obj is Accesory).ToList();

            foreach (var obj in accesories)
            {
                Accesory accesory = (Accesory)obj;
                if (accesory.Movable == this)
                {
                    if (Direction == MobDirection.Up)
                    {
                        accesory.Sprite.Rotation = Directions.Up;
                    }
                    else if (Direction == MobDirection.Down)
                    {
                        accesory.Sprite.Rotation = Directions.Down;
                    }
                    else if (Direction == MobDirection.Left)
                    {
                        accesory.Sprite.Rotation = Directions.Left;
                    }
                    else if (Direction == MobDirection.Right)
                    {
                        accesory.Sprite.Rotation = Directions.Right;
                    }
                }
            }
            #endregion
        }
    }
}
