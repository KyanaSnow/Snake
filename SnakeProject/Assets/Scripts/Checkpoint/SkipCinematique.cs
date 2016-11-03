using UnityEngine;
using System.Collections;

public class SkipCinematique : MonoBehaviour
{
	[SerializeField] private int Id;
	[SerializeField] private GameObject GameObjectSkipCinematique;

	private bool isPlayed;
	private bool wasPlayed;

	void Update()
	{
		if (isPlayed && wasPlayed)
		{

			if (Input.GetKeyDown("A"))
				Skip();
		}
	}

	void Skip()
	{
		if (GameObjectSkipCinematique != null)
			GameObjectSkipCinematique.SetActive(true);
		//display button A
	}

	//event cinematique begin
	public void CineamatiqueIsPlayed()
	{
		isPlayed = true;
		//if (wasPlayed)
		//afficher button A
	}

	//event cinematique was finish
	public void CinematiqueWasPlayed()
	{
		wasPlayed = true;
		isPlayed = false;
		//display button A
		SceneManagerCheckpoint._Instance.SavingCinematiqueWasPlayed(Id);
	}

	#region GetVar
	public int GetId()
	{
		return Id;
	}
	#endregion
}
