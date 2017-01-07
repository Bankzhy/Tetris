using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
    public void OnClick()
    {
        Debug.Log("Button click!");
        // 非表示にする
        GUIManager.restart();
        Application.LoadLevel("sceen");

    }
}
