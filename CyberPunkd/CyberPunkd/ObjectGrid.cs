using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyberPunkd
{
    class ObjectGrid
    {
        //all widths and heights are in tiles
        private int gridWidth;
        private int gridHeight; 
        private int mapWidth;
        private int mapHeight;

        private List<Entity> objects;
        private Grid[][] grids;

        //parameters are expected to be in arrays of x, y format
        public List<Entity> GetActiveObjects(int[] upperLeftCorner, int[] upperRightCorner, int[] lowerLeftCorner, int[] lowerRightCorner)
        {
            List<Entity> activeObjects = new List<Entity>();
            Grid[] foundGrid = new Grid[3];
            foundGrid[0] = FindGrid(upperLeftCorner[0], upperLeftCorner[1]);
            foundGrid[1] = FindGrid(upperRightCorner[0], upperRightCorner[1]);
            foundGrid[2] = FindGrid(lowerLeftCorner[0], lowerLeftCorner[1]);
            foundGrid[3] = FindGrid(lowerRightCorner[0], lowerRightCorner[1]);

            //add grid objects to active objects list
            //add grid0
            activeObjects.AddRange(foundGrid[0].getObjects());
            //add grid1 if it hasn't been added yet
            if (foundGrid[1] != foundGrid[0])
            {
                activeObjects.AddRange(foundGrid[1].getObjects());
            }
            //add grid2 if it hasn't been
            if (foundGrid[2] != foundGrid[1] && foundGrid[2] != foundGrid[0])
            {
                activeObjects.AddRange(foundGrid[2].getObjects());
            }
            //add final grid if it hasn't been
            if (foundGrid[3] != foundGrid[2] && foundGrid[3] != foundGrid[1] && foundGrid[3] != foundGrid[0])
            {
                activeObjects.AddRange(foundGrid[3].getObjects());
            }

            return activeObjects;
        }
        private Grid FindGrid(int x, int y)
        {
            int row = 0;
            int column = 0;

            //determine what row the coordinates are in
            while (x % gridWidth > gridWidth)
            {
                x = x%gridWidth;
                row++;
            }

            //determine what column the coordinates are in
            while (y%gridHeight > gridHeight)
            {
                y = y%gridHeight;
                column++;
            }

            //return the grid at the selected row and column
            return grids[row][column];
        }
    }

    class Grid
    {
        private List<Entity> objects;

        public List<Entity> getObjects()
        {
            return objects;
        }

        public void add(Entity entity)
        {
            objects.Add(entity);
        }

        public void delete(Entity entity)
        {
            objects.Remove(entity);
        }
         
    }
}
