using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

	public class Health_
	{
		public string name;
		public int count;

	};
	 List<Health_> health=new List<Health_>();

	public void AddHealth(string name, int count) {
		int i = 0;
		foreach (var item in health) {
			if (item.name.Equals(name)) {
				break;
			}
			i++;
		}
		if (i >= 3) {
			return;
		}
		Debug.Log(i);
		health[i].count += count;
	}

	public void SpendHealth(string name, int count) {
		int i = 0;
		foreach (var item in health) {
			if (item.name.Equals(name)) {
				break;
			}
			i++;
		}
		health[i].count -= count;
		if (health[i].count<=0)
		{
			health.RemoveAt(i);
			if (i == 0)
			{
				print("1");//后期改进
			}
		}
	}

	public void CreateHealth(string name, int count)
	{
		Health_ temp=new Health_();
		temp.name = name;
		temp.count = count;
		health.Add(temp);
	}

	public int  ShowHealth(string name)
	{
		int i = 0;
		foreach (var item in health) {
			if (item.name.Equals(name)) {
				break;
			}
			i++;
		}

		return health[i].count;
	}
}
