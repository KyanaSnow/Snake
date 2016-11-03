using UnityEngine;
using System.Collections;

public class ElementManager : MonoBehaviour
{

	void Start ()
	{
		SideBar._Instance.SetIndex  += SetIndexFct;
	}
	
	void SetIndexFct(int id)
	{
		Debug.Log("My openingIndex set " + id);
	}
}
