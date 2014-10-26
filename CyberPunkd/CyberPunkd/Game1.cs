using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CyberPunkd
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private int[][] tileMatrix;
        private int[] viewCorner;
        private Tile[] tileTable;
        private const int EMPTY_TILE = 0;
        private const int FLOOR_TILE = 1;

        private const int WALL_LEFT_TILE = 2;
        private const int WALL_TOP_TILE = 3;
        private const int WALL_BOTTOM_TILE = 4;
        private const int WALL_RIGHT_TILE = 5;
        private const int WALL_LL_TILE = 6;
        private const int WALL_UL_TILE = 7;
        private const int WALL_UR_TILE = 8;
        private const int WALL_LR_TILE = 9;
        

        private const int TILE_WIDTH = 64;
        private const int TILE_HEIGHT = 64;
        private const int SCREEN_WIDTH = 1280;
        private const int SCREEN_HEIGHT = 800;
        private const int HORIZONTAL_TILES = SCREEN_WIDTH/TILE_WIDTH;
        private const int VERTICAL_TILES = SCREEN_HEIGHT/TILE_HEIGHT;



        private Player player;

        //Just for testing
        private Tile tile;
        //public static ContentManager content;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //content = Content;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT-64-32;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH-64;
            graphics.ApplyChanges();
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Drawable.setSpriteBatch(spriteBatch);
            player = new Player(Content.Load<Texture2D>(@"SpriteSheets\Female_sheet"));
            tile = new Floor(Content.Load<Texture2D>(@"SpriteSheets\floor"));

            // TODO: use this.Content to load your game content here
            //load sprite maps
            
            //load tilesets
            tileTable = new Tile[9];
            tileTable[FLOOR_TILE] = tile;

            tileTable[WALL_LEFT_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_LEFT_TILE].setSpriteFrame(new Point(0,0));

            tileTable[WALL_TOP_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_TOP_TILE].setSpriteFrame(new Point(1, 0));

            tileTable[WALL_BOTTOM_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_BOTTOM_TILE].setSpriteFrame(new Point(2, 0));

            tileTable[WALL_RIGHT_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_RIGHT_TILE].setSpriteFrame(new Point(3, 0));

            tileTable[WALL_LL_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_LL_TILE].setSpriteFrame(new Point(0, 1));

            tileTable[WALL_UL_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_UL_TILE].setSpriteFrame(new Point(1, 1));

            tileTable[WALL_UR_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_UR_TILE].setSpriteFrame(new Point(2, 1));

            tileTable[WALL_LR_TILE] = new Wall(Content.Load<Texture2D>("Walls"));
            tileTable[WALL_LR_TILE].setSpriteFrame(new Point(3, 1));
            
            //load map files
            LoadMap("tutorial");
            viewCorner = new[] {0, 0};

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //player update
                //sense input
            KeyboardState keys = Keyboard.GetState();
            
                //compute restrictions
                //update player stats
            //world update
                //passive elements
                    //select active zone
                //logic elements
                    //sort by relevance
                    //sense internal state/goals
                    //sense restrictions
                    //decision engine
                    //update world


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            

            // TODO: Draw world
            // TODO: Draw Player
            spriteBatch.Begin();
            //player.draw(gameTime, );
            //tile.draw(gameTime,100,100);
            DrawMap(gameTime);
            spriteBatch.End();


            base.Draw(gameTime);
        }

        private void LoadMap(string mapname)
        {
            string filePath;
            StreamReader sr;
            switch (mapname)
            {
                case "tutorial":
                    filePath = "Content/maps/Tutorial Map.csv";
                    break;
                default:
                    filePath = "Content/maps/Tutorial Map.csv";
                    break;
            }

            sr = new StreamReader(filePath);
            var lines = new List<int[]>();
            while (!sr.EndOfStream)
            {
                string[] line  = sr.ReadLine().Split(',');
                int[] intLine = new int[line.GetLength(0)];
                for (int i = 0; i < line.GetLength(0); i++)
                {
                    intLine[i] = int.Parse(line[i]);
                }
                lines.Add(intLine);
            }

            tileMatrix = lines.ToArray();
            sr.Close();
        }

        private void DrawMap(GameTime gameTime)
        {
            for (int x = 0; x < HORIZONTAL_TILES-1; x++)
            {
                for (int y = 0; y < VERTICAL_TILES-1; y++)
                {
                    //check that the desired [x,y] is within the map
                    int xGlobal = viewCorner[0] + x;
                    int yGlobal = viewCorner[1] + y;
                    if (tileMatrix.GetLength(0) > yGlobal)
                    {
                        if (tileMatrix[0].GetLength(0) > xGlobal)
                        {
                            //we're still on the map
                            //paint the tile at tileMatrix[xGlobal, yGlobal] at coords [x,y]
                            int tileTableIndex = tileMatrix[yGlobal][xGlobal];
                            if (tileTableIndex != EMPTY_TILE)
                            {
                                tileTable[tileTableIndex].draw(gameTime,x, y);
                            }
                            
                        }
                        else
                        {
                            //we're off the map, paint empty tile
                            //tileTable[EMPTY_TILE].draw(gameTime,x, y);

                        }
                    }
                    else
                    {
                        //we're off the map, paint empty tile
                        //tileTable[EMPTY_TILE].draw(gameTime, x, y);
                    }
                }
            }
        }
    }
}
