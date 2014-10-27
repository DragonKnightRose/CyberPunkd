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

        private const int WALL_LL_CORNER = 10;
        private const int WALL_UL_CORNER = 11;
        private const int WALL_UR_CORNER = 12;
        private const int WALL_LR_CORNER = 13;
        

        private const int TILE_WIDTH = 64;
        private const int TILE_HEIGHT = 64;
        private const int SCREEN_WIDTH = 1280;
        private const int SCREEN_HEIGHT = 800;
        private const int HORIZONTAL_TILES = SCREEN_WIDTH/TILE_WIDTH;
        private const int VERTICAL_TILES = SCREEN_HEIGHT/TILE_HEIGHT;

        private int[] viewCorner;
        private Player player;

        private TimeSpan timeSinceLastMove;
        private TimeSpan lastMove;
        private TimeSpan tickTime;

        private Texture2D wallSpriteMap;


        //Just for testing
        private Tile tile;
        //public static ContentManager content;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //content = Content;
            //TargetElapsedTime = new TimeSpan(1000);
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

            lastMove = new TimeSpan(0,0,0);
            tickTime = TargetElapsedTime;
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
            player = new Player(Content.Load<Texture2D>(@"SpriteSheets\Female_sheet"), tickTime);
            tile = new Floor(Content.Load<Texture2D>(@"SpriteSheets\floor"));

            // TODO: use this.Content to load your game content here
            //load sprite maps
            wallSpriteMap = Content.Load<Texture2D>(@"SpriteSheets\Walls");
            
            //load tilesets
            tileTable = new Tile[22];
            tileTable[FLOOR_TILE] = tile;

            tileTable[WALL_LEFT_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_LEFT_TILE].setSpriteFrame(new Point(0,0));

            tileTable[WALL_TOP_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_TOP_TILE].setSpriteFrame(new Point(1, 0));

            tileTable[WALL_BOTTOM_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_BOTTOM_TILE].setSpriteFrame(new Point(2, 0));

            tileTable[WALL_RIGHT_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_RIGHT_TILE].setSpriteFrame(new Point(3, 0));

            tileTable[WALL_LL_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_LL_TILE].setSpriteFrame(new Point(0, 1));

            tileTable[WALL_UL_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_UL_TILE].setSpriteFrame(new Point(1, 1));

            tileTable[WALL_UR_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_UR_TILE].setSpriteFrame(new Point(2, 1));

            tileTable[WALL_LR_TILE] = new Wall(wallSpriteMap);
            tileTable[WALL_LR_TILE].setSpriteFrame(new Point(3, 1));

            tileTable[WALL_LL_CORNER] = new Wall(wallSpriteMap);
            tileTable[WALL_LL_CORNER].setSpriteFrame(new Point(0, 2));

            tileTable[WALL_UL_CORNER] = new Wall(wallSpriteMap);
            tileTable[WALL_UL_CORNER].setSpriteFrame(new Point(1, 2));

            tileTable[WALL_UR_CORNER] = new Wall(wallSpriteMap);
            tileTable[WALL_UR_CORNER].setSpriteFrame(new Point(2, 2));

            tileTable[WALL_LR_CORNER] = new Wall(wallSpriteMap);
            tileTable[WALL_LR_CORNER].setSpriteFrame(new Point(3, 2));
            
            //load map files
            viewCorner = new[] {0, 0};
            LoadMap("tutorial");

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
            timeSinceLastMove = gameTime.TotalGameTime - lastMove;
                //sense input
            if (timeSinceLastMove > new TimeSpan (5 * tickTime.Ticks))
            {
                lastMove = gameTime.TotalGameTime;
                MovePlayer();


                //compute restrictions
                bool collide = CheckWallCollision();
                Console.WriteLine("collide: :" + collide);

                //update player stats
                if (!collide)
                {
                    MoveView();
                }
            }
            else
            {
                player.update(gameTime);
            }         

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
            player.draw(gameTime, new Point(640, 368));
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
                    filePath = @"Content/maps/Tutorial Map.csv";
                    viewCorner[0] = 0;
                    viewCorner[1] = 10;
                    break;
                default:
                    filePath = @"Content/maps/Tutorial Map.csv";
                    viewCorner[0] = 0;
                    viewCorner[1] = 10;
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
                            if (tileTableIndex != EMPTY_TILE && tileTableIndex != 15)
                            {
                                tileTable[tileTableIndex].draw(gameTime, x, y);
                            }
                            else
                            {
                                //tileTable[FLOOR_TILE].draw(gameTime, x, y);
                            }

                        }
                    }
                }
            }
        }

        private void MoveView()
        {
            KeyboardState keys = Keyboard.GetState();
            Player.States state = player.getState();
            //player pressing up
            if (state == Player.States.WalkUp)
            {
                viewCorner[1] = viewCorner[1] - 1;
                if (viewCorner[1] < 0)
                {
                    viewCorner[1] = 0;
                }
            }
            else
            {
                //player pressing down
                if (state == Player.States.WalkDown)
                {
                    viewCorner[1] = viewCorner[1] + 1;
                    if (viewCorner[1] > tileMatrix.GetLength(0) - 10)
                    {
                        viewCorner[1] = tileMatrix.GetLength(0) - 10;
                    }
                }
                else
                {
                    //player pressing left
                    if (state == Player.States.WalkLeft)
                    {
                        viewCorner[0] = viewCorner[0] - 1;
                        if (viewCorner[0] < 0)
                        {
                            viewCorner[0] = 0;
                        }
                    }
                    else
                    {
                        //player pressing right
                        if (state == Player.States.WalkRight)
                        {
                            viewCorner[0] = viewCorner[0] + 1;
                            if (viewCorner[0] > tileMatrix[0].GetLength(0) - 10)
                            {
                                viewCorner[0] = tileMatrix[0].GetLength(0) - 10;
                            }
                        }
                    }
                    
                }
               
            }
            
        }

        public void MovePlayer()
        {
            KeyboardState keys = Keyboard.GetState();

            player.ParseInput(keys);
            
        }

        public bool CheckWallCollision()
        {
            int destinationTileType;
            int destinationX;
            int destinationY;
            switch (player.getState())
            {
                case (Player.States.WalkUp):
                    destinationX = viewCorner[0] + player.getXCoord();
                    destinationY = viewCorner[1] + player.getYCoord() - 1;
                    break;
                case (Player.States.WalkDown):
                    destinationX = viewCorner[0] + player.getXCoord();
                    destinationY = viewCorner[1] + player.getYCoord() + 1;
                    break;
                case (Player.States.WalkRight):
                    destinationX = viewCorner[0] + player.getXCoord() + 1;
                    destinationY = viewCorner[1] + player.getYCoord();
                    break;
                case (Player.States.WalkLeft):
                    destinationX = viewCorner[0] + player.getXCoord() - 1;
                    destinationY = viewCorner[1] + player.getYCoord();
                    break;
                default:
                    return false;
            }

            destinationTileType = tileMatrix[destinationY][destinationX];

            //debug info
            Console.WriteLine("Player X:" + (player.getXCoord()+viewCorner[0]));
            Console.WriteLine("Player Y:" + (player.getYCoord()+viewCorner[1]));
            Console.WriteLine("Destination Tile: (" + destinationX + ", " + destinationY + ")");
            Console.WriteLine("Tile Type: " + destinationTileType);

            if (destinationTileType != EMPTY_TILE && destinationTileType != 15)
                return tileTable[destinationTileType].canCollide;
            else
            {
                return false;
            }
        }
    }
}
