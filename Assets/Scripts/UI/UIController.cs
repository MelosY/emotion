using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	// Use this for initialization
	public consumeManager ConsumeCount;
	public Slider slider_player;
	public Text text_player;
	public Slider slider_enemy;
	public Text text_enemy;
	public Text expense_player;
	public Text expense_enemy;
	public Text bonus;
	public Text grade;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		slider_player.value = ConsumeCount.show(0, "health");
		text_player.text =  ConsumeCount.show(0, "health").ToString();
		expense_player.text = ConsumeCount.show(0, "expense").ToString();
		if ( ConsumeCount.show(1, "health") > 0)
		{
			text_enemy.text = ConsumeCount.show(1, "health").ToString();
			slider_enemy.value =ConsumeCount.show(1, "health");
			expense_enemy.text =ConsumeCount.show(1, "expense").ToString();
		}
		else
		{
			text_enemy.text = "怪物死了";
		}
	}


	public void showBonus(int x)
	{
		string temp = "bonus:" + x;
		bonus.text = temp;
	}

	public void showGrade(string effect)
	{
		grade.text = "grade:"+effect;
		StartCoroutine(wait());
	}

	public IEnumerator wait()
	{
		print(122311);
		yield return  new WaitForSeconds(2f);
		grade.text = "";
		print(1233221);
	}
	
}
