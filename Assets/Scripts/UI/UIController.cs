using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	// Use this for initialization
	public playerUnit player;//先改一下
	public Slider slider_player;
	public Text text_player;
	public Slider slider_enemy;
	public Text text_enemy;
	public Text expense_player;
	public Text expense_enemy;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		slider_player.value = player.health_manager.show("player");
		text_player.text = player.health_manager.show("player").ToString();
		slider_enemy.value = player.health_manager.show("majika");
		text_enemy.text = player.health_manager.show("majika").ToString();
		expense_player.text = player.expense_manager.show("player").ToString();
		expense_enemy.text = player.expense_manager.show("majika").ToString();
	}
}
