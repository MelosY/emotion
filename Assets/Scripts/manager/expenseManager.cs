using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expenseManager : MonoBehaviour
{

	public Expense expense;
	
	// Use this for initialization
	public void create(string name, int count)
	{
		expense.CreateExpense(name,count);
	}

	public void damage(string name ,int count)
	{
		expense.SpendExpense(name,count);
		//print(123);
	}

	public  int show(string name)
	{
		return expense.ShowExpense(name);
	}
}
