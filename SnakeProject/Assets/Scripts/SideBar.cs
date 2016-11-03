using UnityEngine;
using System.Collections;

public class SideBar : MonoBehaviour
{
	public static SideBar _Instance;
	public delegate void SetOpeningIndex(int id);
	public event SetOpeningIndex SetIndex; 

	void Awake()
	{
		_Instance = this;
	}

	void Start()
	{
		OpenedIndex = 5;
	}

	private int openedIndex;
	public int OpenedIndex
	{
		get
		{
			return openedIndex;
		}
		set
		{
			openedIndex = value;
			SetIndex(openedIndex);
		}
	}
}
