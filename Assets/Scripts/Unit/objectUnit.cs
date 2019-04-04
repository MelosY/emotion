using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectUnit : MonoBehaviour
{

	private SpriteRenderer sr;

	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}
	/*public executeManager ExecuteManager; 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseOver()
	{
		transform.position+=new Vector3(0,0.5f,0);
	}

	private void OnMouseDown()
	{
		ExecuteManager.execute();
	}*/
	public Sprite[] cardImage;
	public void showBack(int type)
	{
		if (type == 1)
		{
			sr.sprite = cardImage[0];
		}
	}
}
