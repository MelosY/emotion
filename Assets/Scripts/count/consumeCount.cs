using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consumeCount : MonoBehaviour {

	public class Count_
	{
		public int count;

	};
	List<List<Count_>> 	Count=new List<List<Count_>> ();

	public void initCount()
	{
		List<Count_> temp1=new List<Count_>();
		Count.Add(temp1);
		List<Count_> temp2=new List<Count_>();
		Count.Add(temp2);
	}
	public void AddCount(int type,string name, int count) 
	{
		if(name=="health")
		{
			Count[0][type].count+=count;
		}
		else if (name=="expense")
		{
			Count[1][type].count+=count;
		}
	}

	public void SpendCount(int type, string name, int count)
	{
	
		if(name=="health")
		{
			Count[0][type].count-=count;
			if (Count[0][type].count<=0)
			{
				//health.RemoveAt(i);
				if (type == 0)
				{
					print("1");//后期改进
				}
			}
			
		}
		else if (name=="expense")
		{
			Count[1][type].count-=count;
			if (Count[0][type].count<=0)
			{
				//health.RemoveAt(i);
				if (type == 0)
				{
					print("1");//后期改进
				}
			}
		}
		
	}



	public int  ShowCount(int type,string name)
	{
		if(name=="health")
		{
			return Count[0][type].count;
		}
		else if (name == "expense")
		{
			return Count[1][type].count;
		}
		else
			return 0;
	}
	
	    
	public void createCount(int type,string name,int count)
	{
		Count_ temp =new Count_();
		temp.count = count;
		if(name=="health")
		{
			Count[0].Add(temp);
			print(Count[0][0].count);
		}
		else if (name=="expense")
		{
			Count[1].Add(temp);
		}
	}
}
