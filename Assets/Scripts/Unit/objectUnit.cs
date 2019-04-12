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

	public Sprite[] cardImage;
	public void showBack(int type)
	{
		if (type == 1)
		{
			sr.sprite = cardImage[0];
		}
	}
}
