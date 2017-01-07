using UnityEngine;
using System.Collections;

public class InputButton : MonoBehaviour {

    public void UpOnClick()
    {
        Group.inp(1);
    }
    public void DownOnClick()
    {
        Group.inp(2);
    }
    public void LeftOnClick()
    {
        Group.inp(3);
    }
    public void RightOnClick()
    {
        Group.inp(4);
    }
}
