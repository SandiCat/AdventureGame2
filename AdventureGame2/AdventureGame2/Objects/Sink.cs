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
    public class Sink : Furniture
    {
        public Sink()
            : base()
        {
        }
        public Sink(Vector2 position)
            : base(position)
        {
        }
        public Sink(Vector2 position, FurnitureDirection direction)
            : base(position, direction)
        {
        }
    }
}
