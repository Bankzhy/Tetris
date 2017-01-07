using UnityEngine;
using System.Collections;


public class Group : MonoBehaviour {
    float p = 0.5f;
    float lastFailTime;
    static bool up, down, left, right;


    // Use this for initialization
    void Start () {
        if (!isVaild())
        {
            Debug.Log("gmae pver");
            GUIManager.gameover();
            Destroy(this.gameObject);
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow) || up ==true)
        {
            if (this.tag != "TO")
            {

                transform.RotateAround(new Vector3(transform.position.x, transform.localPosition.y - 0.25f, 0), Vector3.back, -90);
                if (isVaild())
                {
                    updataGrid();
                }
                else
                {
                    transform.RotateAround(new Vector3(transform.position.x, transform.position.y + 0.25f, 0), Vector3.back, -90);
                }
            }
            up = false;
        }
        
        else if (Input.GetKeyDown(KeyCode.DownArrow)||down ==true||Time.time-lastFailTime>=1)
        {
            transform.position += new Vector3(0, -p,0);
            if (isVaild())
            {
                updataGrid();
            }
            else
            {
                transform.position += new Vector3(0, +p, 0);
                Gird.deleteFullRow();
                FindObjectOfType<GenT>().nextSpawner();
                enabled = false;
            }
            lastFailTime = Time.time;
            down = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) ||left==true)
        {
            transform.position += new Vector3(-p,0,0);
            if (isVaild())
            {
                updataGrid();
            }
            else
            {
                transform.position += new Vector3(+p, 0, 0);
            }
            left = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)||right==true){
            transform.position += new Vector3(+p, 0, 0);
            if (isVaild())
            {
                updataGrid();
            }
            else
            {
                transform.position = new Vector2(transform.position.x - p, transform.position.y);
            }
            right = false;
        }
	
	}

    void updataGrid()
    {
        for (int y = 0; y <Gird.h; y++)
        {
            for (int x = 0; x < Gird.w; x++)
            {
                if (Gird.grid[x, y] != null)
                {
                    if (Gird.grid[x, y].parent == transform)
                    {
                        Gird.grid[x, y] = null;
                    }
                }
            }
        }


        foreach (Transform child in transform)
        {
            Vector2 v = Gird.changeToGrid(child.position);
         
            Gird.grid[(int)v.x, (int)v.y] = child;
            
        }
    }

    bool isVaild() {
        foreach(Transform child in transform)
        {
            Vector2 v = Gird.changeToGrid(child.position);

            if (!Gird.insideBoarder(v))
            {
                return false;
            }

            if (Gird.grid[(int)v.x, (int)v.y] != null &&
               Gird.grid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    public static void inp(int i)
    {
        switch (i)
        {
            case 1:
                up = true;
                break;
            case 2:
                down = true;
                break;
            case 3:
                left = true;
                break;
            default:
                right = true;
                break;
        }
    } 


}
