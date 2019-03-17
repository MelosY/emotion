using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{

	public Health health;
	// Use this for initialization
	public void create(string name, int count)
	{
		health.CreateHealth(name,count);
	}

	public void damage(string name ,int count)
	{
		health.SpendHealth(name,count);
	}

	public  int show(string name)
	{
		return health.ShowHealth(name);
	}
}
