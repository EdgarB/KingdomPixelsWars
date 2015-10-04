using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {

	public void goToSceneWithName(string sName)
    {
        Application.LoadLevel(sName);
    }
}
