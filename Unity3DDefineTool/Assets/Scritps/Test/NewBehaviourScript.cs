using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
#if wewe
		GUI.Label(new Rect(0,40,200,30),"wewe");
#endif
#if test1
		GUI.Label(new Rect(0,0,200,30),"test1");
#endif
#if test2
		GUI.Label(new Rect(0,0,200,30),"test2");
#endif
#if test3
		GUI.Label(new Rect(0,0,200,30),"test3");
#endif
	}
}
