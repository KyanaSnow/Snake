using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HierarchyHighlighterComponent : MonoBehaviour
{
	//attach this to the gameobject you want to highlight in the hierarchy
	[System.Serializable]
	public class MyClass
	{
		public int id;
		public string name;
	}

	[System.Serializable]
	public class ThingWithArray
	{
		public MyClass[] array;

		public MyClass this[int i]
		{
			get
			{
				return array[i];
			}
			set
			{
				array[i] = value;
			}
		}
	}

	public ThingWithArray[] list;

	void Start()
	{
		var test = list[0][0];
		Debug.Log("test" + test.name);
	}


	//public bool highlight = false;
	//public Color color;
}
