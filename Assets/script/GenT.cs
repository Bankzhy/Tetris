using UnityEngine;
using System.Collections;

public class GenT : MonoBehaviour {
    public  GameObject[] groups = new GameObject[7];

    // Use this for initialization
    void Start () {
        nextSpawner();
	}
    public  void nextSpawner(){
        int i = Random.Range(0, 7);
        Vector2 gpos1 = new Vector2(0.25f, 4.75f);//I
        Vector2 gpos2 = new Vector2(0.25f, 4.5f);//o
        Vector2 gpos3 = new Vector2(0, 4.5f);//other
        if (i == 0)
        {
            GameObject g = Instantiate(groups[i], gpos1, Quaternion.identity) as GameObject;
        }
        else if (i == 3)
        {
            GameObject g = Instantiate(groups[i], gpos2, Quaternion.identity) as GameObject;
        }
        else
        {
            GameObject g = Instantiate(groups[i], gpos3, Quaternion.identity) as GameObject;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
