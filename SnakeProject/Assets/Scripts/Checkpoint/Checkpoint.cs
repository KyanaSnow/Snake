using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
	[SerializeField] private int idCheckPoint;
	[SerializeField] private GameObject GameObjectActiveLoad;
	[SerializeField] private GameObject DummyCheckPoint;

	public void LoadCheckPoint()
	{
		//placer le player et lily au bon endroit
		if (GameObjectActiveLoad != null)
			GameObjectActiveLoad.SetActive(true);
	}

	#region GetVar
	public int GetIdCheckPoint()
	{
		return idCheckPoint;
	}
	#endregion
}
