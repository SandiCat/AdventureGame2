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
    public class PlayerSword : Accesory
    {
        public PlayerSword()
            : base()
        {
        }
        public PlayerSword(Vector2 position)
            : base(position)
        {
        }
        public PlayerSword(Mob mob)
            : base(mob)
        {
            _swordAlarm.Restart(10);
        }

        Alarm _swordAlarm = new Alarm();

        protected override void Update()
        {
            //Delete the sword when alarm is over:
            if (_swordAlarm.IsDone())
            {
                PlayerSword sword = (PlayerSword)ObjectHolder.Objects.Where((obj) => obj.GetType() == typeof(PlayerSword)).ToList()[0];

                ObjectHolder.Delete(sword);
            }

            base.Update();
        }
    }
}