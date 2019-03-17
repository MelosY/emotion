using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[Serializable]
public class Player {

	
	[Header("UI")]
	public UIController UI;

	[Header("Health")] 
	public healthManager he;

}

public class playerController : MonoBehaviour
{

	public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
