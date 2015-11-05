using UnityEngine;
using System.Collections;

public class SGGameScreenSettingConroller : MonoBehaviour {

	public bool FullScreen = false;

	// Use this for initialization
	void Start () 
	{
		Screen.fullScreen = this.FullScreen;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
