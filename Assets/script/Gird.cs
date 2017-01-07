using UnityEngine;
using System.Collections;

public class Gird : MonoBehaviour {
    public static int w = 11;
    public static int h = 21;
    public static Transform[,] grid = new Transform[11,21];

    public static float p = 0.5f;
    
    public static Vector2 changeToGrid(Vector2 pos)
    {
        float nx = pos.x - (-2.5f);
        float ny = pos.y - (-5.25f);
        float gposw = nx / p;
        float gposh = ny / p;

        return new Vector2(gposw, gposh);
    }

    public static bool insideBoarder(Vector2 pos)
    {
        return pos.x >= 0 && pos.x <11 && pos.y >=0;
    }
    public static bool isRowFull(int y)
    {
        for(int x=0; x < w; x++)
        {
            if (grid[x, y] ==null)
            {
                return false;
            }

        }
        return true;
    }
    public static void deleteRow(int y)
    {
        for(int x=0; x < w; x++)
        {
            Destroy(grid[x, y].gameObject);

            grid[x, y] = null;

        }
        GUIManager.addPoint();
    }

    public static void deleteFullRow()
    {
        for (int y = 0; y < h;)
        {
            if (isRowFull(y))
            {
                //print("kk");
                deleteRow(y);
                decreaseRowAbove(y + 1);
            }
            else
            {
                y++;
            }
        }
    }

    public static void decreaseRow(int y)
    {
        for(int x = 0; x < w; x++)
        {
            if (grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -p, 0);
            }
        }
    }
    public static void decreaseRowAbove(int y)
    {
        for(int i = y; i < h; i++)
        {
            decreaseRow(i);
        }
    }
}
