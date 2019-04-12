using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{

	public bool isgame = false;
	public bool ismap = true;
	public battleSystem battle;
	private Vector3 gameScene=new Vector3(0,0,-10);
	
	public Camera camera;
	void Start()
	{
		
	}


	void Update()
	{
		if (Input.GetKeyUp("n"))
		{
			camera.transform.position = gameScene;
			battle.enabled = true;
		}
	}
}
