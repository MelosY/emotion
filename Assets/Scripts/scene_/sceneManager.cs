using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour {

	private Vector3 offset=new Vector3(-42f,-9.7f,-10);
	public Camera camera;
	void Start()
	{
		
	}


	void Update()
	{
		if (Input.GetKeyUp("n"))
		{
			camera.transform.position = offset;
		}
	}
}
