using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expense : MonoBehaviour {

	public class Expense_
	{
		public string name;
		public int count;

	};
	List<Expense_> expense=new List<Expense_>();

	public void AddExpense(string name, int count) {
		int i = 0;
		foreach (var item in expense) {
			if (item.name.Equals(name)) {
				break;
			}
			i++;
		}
		if (i >= 3) {
			return;
		}
		Debug.Log(i);
		expense[i].count += count;
	}

	public void SpendExpense(string name, int count) {
		int i = 0;
		foreach (var item in expense ){
			if (item.name.Equals(name)) {
				break;
			}
			i++;
		//	print("111");
		}
		
		if (expense[i].count >= count)
		{
			expense[i].count -= count;
			if (i == 0)
			{
				print("1");//后期改进
			}
		}
	}

	public void CreateExpense(string name, int count)
	{
		Expense_ temp=new Expense_();
		temp.name = name;
		temp.count = count;
		expense.Add(temp);
	}

	public int  ShowExpense(string name)
	{
		int i = 0;
		foreach (var item in expense) {
			if (item.name.Equals(name)) {
				break;
			}
			i++;
		}

		return expense[i].count;
	}
}
