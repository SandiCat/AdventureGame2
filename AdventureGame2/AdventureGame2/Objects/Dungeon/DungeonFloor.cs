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
    public class DungeonFloor : Floor
    {
        public DungeonFloor()
            : base()
        {
        }
        public DungeonFloor(Vector2 position)
            : base(position)
        {
        }

        protected override void Update()
        {
        }
    }
}
