using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    float starttime;
    public Text timer;
    public  Text Score;
    public GameObject End;
    static int point=0;
    static bool isEnd=false;
	// Use this for initialization
	void Start () {
        timer=timer.GetComponent<Text>();
        Score = Score.GetComponent<Text>();

        starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float time = Time.time - starttime;
        int min = (int)time / 60;
        int sec = (int)time % 60;
        string timestr = string.Format("{0:00}:{1:00}", min, sec);
        timer.text = timestr;

        string score = point.ToString();
        Score.text = score;
        if (isEnd == true)
        {
            End.SetActive(true);
        }
        else
        {
            End.SetActive(false);
        }
    }
     public static void addPoint()
    {
        point = point + 10;

    }
    
    public static void gameover()
    {
        isEnd = true;
    } 
    public static void restart()
    {
        isEnd = false;
    }

}
