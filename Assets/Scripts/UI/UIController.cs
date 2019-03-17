using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	// Use this for initialization
	public enemyUnit player;//先改一下
	public Slider healthLine;
	public Text text_health;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthLine.value = player.health_manager.show("majika");
		text_health.text = player.health_manager.show("player").ToString();
	}
}
