using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumeManager : MonoBehaviour {

	public consumeCount Consume;
	// Use this for initialization
	public void create(int type,string name, int count)
	{
		Consume.createCount(type,name,count);
	}

	public void damage(int type,string name ,int count)
	{
		Consume.SpendCount(type,name,count);
	}

	public  int show(int type,string name)
	{
		return Consume.ShowCount(type, name);
	}

	public void recover(int type, string name, int count)
	{
		Consume.AddCount(type,name,count);
	}

	public void init()
	{
		Consume.initCount();
	}
}
