using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame.Utils;
using Library.EntityComponentSystem;
using Library.EntityComponentSystem.Components;
using MyGame.Data.Systems;
using MyGame.Data.Factories;
using System.Diagnostics;
using System.Linq;
using MyGame.Data.Components;

namespace MyGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MyGame : Game
    {
        private static MyGame _instance;

        public static MyGame Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MyGame();
                }

                return _instance;
            }
        }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Stopwatch _stopwatch;
        private double _updateTime;

        public TextureManager TextureManager { get; private set; }
        public World World { get; private set; }

        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }
        public int SpriteWidth { get; private set; }
        public int SpriteHeight { get; private set; }

        public MyGame()
        {
            ScreenWidth = 1366;
            ScreenHeight = 768;
            SpriteWidth = 32;
            SpriteHeight = 32;

            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            //_graphics.PreferMultiSampling = true;
            //_graphics.GraphicsProfile = GraphicsProfile.HiDef;
            //_graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            FontManager.Instance.LoadFonts(this);

            var spriteSheet = Content.Load<Texture2D>("Textures/spritesheet");
            TextureManager = new TextureManager(spriteSheet, 32, 32);

            World = new World();

            var player = World.EntityManager.CreateEntity();
            FactoryEntity.CreatePlayer(player);

            for (int i = 0; i < 10; i++)
            {
                var ennemy = World.EntityManager.CreateEntity();
                FactoryEntity.CreateEnnemy3(ennemy, 100 + (i * 38), 100, Color.White);
                ennemy = World.EntityManager.CreateEntity();
                FactoryEntity.CreateEnnemy1(ennemy, 100 + (i * 38), 125, Color.White);
                ennemy = World.EntityManager.CreateEntity();
                FactoryEntity.CreateEnnemy1(ennemy, 100 + (i * 38), 150, Color.White);
                ennemy = World.EntityManager.CreateEntity();
                FactoryEntity.CreateEnnemy2(ennemy, 100 + (i * 38), 175, Color.White);
                ennemy = World.EntityManager.CreateEntity();
                FactoryEntity.CreateEnnemy2(ennemy, 100 + (i * 38), 200, Color.White);
            }

            //var soucoupe = World.EntityManager.CreateEntity();
            //FactoryEntity.CreateEnnemy4(soucoupe, 30, 20, Color.Red);

            World.SystemManager.AddSystem(new InputSystem());
            World.SystemManager.AddSystem(new DrawEntitySystem());
            World.SystemManager.AddSystem(new DrawEntityDeathSystem());
            World.SystemManager.AddSystem(new MoveToSystem());
            World.SystemManager.AddSystem(new MoveEnemiesSystem());
            World.SystemManager.AddSystem(new ShootPlayerSystem());
            World.SystemManager.AddSystem(new ShootEnemiesSystem());
            World.SystemManager.AddSystem(new MoveShootsSystem());
            World.SystemManager.AddSystem(new CollisionShootSystem());
            World.SystemManager.AddSystem(new EndGameSystem());

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _stopwatch.Restart();
            World.Update(gameTime.ElapsedGameTime.TotalMilliseconds);

            _updateTime = _stopwatch.Elapsed.TotalMilliseconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _stopwatch.Restart();
            World.Draw(gameTime.ElapsedGameTime.TotalMilliseconds, _spriteBatch);
            
            _spriteBatch.DrawString(FontManager.Instance.GetFont(FontEnum.ARIAL_16), "Draw : " + _stopwatch.Elapsed.TotalMilliseconds.ToString("0.00") + " ms", new Vector2(10, 10), Color.Yellow);
            _spriteBatch.DrawString(FontManager.Instance.GetFont(FontEnum.ARIAL_16), "Update : " + _updateTime.ToString("0.00") + " ms", new Vector2(10, 30), Color.Yellow);


            //Affichage vie + score player
            var player = World.EntityManager.GetEntities().Where(x => ((TypeComponent)x.GetComponent(5)).Type == Data.Enums.EnumTypeEntity.PLAYER).FirstOrDefault();

            if (player != null)
            {
                var scoreComponent = ((ScoreComponent)player.GetComponent(9));
                _spriteBatch.DrawString(FontManager.Instance.GetFont(FontEnum.ARIAL_16), "Score : " + scoreComponent.Score, new Vector2(10, 50), Color.Yellow);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
