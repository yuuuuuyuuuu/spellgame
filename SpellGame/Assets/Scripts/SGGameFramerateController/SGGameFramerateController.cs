using UnityEngine;
using System.Collections;

public class SGGameFramerateController : MonoBehaviour {

	public int TargetFramerate = 60;

	void Awake()
	{
		this.setFramerate(this.TargetFramerate);
	}

	private void setFramerate(int trgtFr)
	{
		SGGameDebugUtil.Log("setFramerate [" + trgtFr + "]");
		Application.targetFrameRate = trgtFr;
	}
}
