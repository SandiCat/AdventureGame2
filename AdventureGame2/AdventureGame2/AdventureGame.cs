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
    public class AdventureGame : Microsoft.Xna.Framework.Game
    {
        //Basic game info:
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static GraphicsDevice Device;

        public AdventureGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Device = graphics.GraphicsDevice;

            //Initialize game info:
            graphics.PreferredBackBufferWidth = 620;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Adventure Game 2.0";

            //Initialize the static classes:
            ObjectHolder.Initialize();
            KeyboardManager.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Initialize the GameInfo:
            GameInfo.RefSpriteBatch = spriteBatch;
            GameInfo.RefDevice = Device;
            GameInfo.RefDeviceManager = graphics;
            GameInfo.RefContent = Content;

            //Initialize some more static classes:
            TextureHolder.Initialize();
            SoundHolder.Initialize();
            MouseManager.Initialize();

            //Initalize the grid:
            Grid.Initialize(40);

            //Initialize default sprites:
            TextureHolder.DefaultTextures[typeof(DungeonWall)] = TextureHolder.ColoredRectangle(Color.Black, Grid.SquareSide, Grid.SquareSide);
            TextureHolder.DefaultTextures[typeof(Player)] = TextureHolder.ColoredRectangle(Color.Yellow, Grid.SquareSide, Grid.SquareSide);

            //Load sounds:

            //Create game objects:
            TileObjectCreator.CreateWithinGrid(
                new Dictionary<char, Type>()
                {
                    {'w', typeof(DungeonWall)},
                    {'p', typeof(Player)},
                    {'.', null}
                },
                new string[]{
                    "wwwwwwwwwwwwww",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w.....p......w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "w............w",
                    "wwwwwwwwwwwwww"
                });

            //Make a reference to the UI objects: (so that other objects can interact with them)
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Events.RiseUpdate();
            Events.RiseUpdateEnded();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();
            Events.RiseDraw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
