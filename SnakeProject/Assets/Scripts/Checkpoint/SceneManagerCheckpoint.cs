using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManagerCheckpoint : MonoBehaviour
{
	public static SceneManagerCheckpoint _Instance;

	#region EventDelegate
	public delegate void SavingingCheckPoint(int idScene, int idCheckPoint);
	public event SavingingCheckPoint SaveCheckPoint;

	public delegate void SavingingCinematique(int idScene, int idCinematique);
	public event SavingingCinematique SaveCinematique;
	#endregion

	[SerializeField] private int SceneId;

	private List<Checkpoint> listCheckPoint;
	private List<SkipCinematique> listCinematique;

	void Awake()
	{
		if (_Instance == null)
			_Instance = this;
		else if (_Instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

	}

	void GetListInScene()
	{
		var CheckPointArray = FindObjectsOfTypeAll(typeof(Checkpoint)) as Checkpoint[];
		listCheckPoint = new List<Checkpoint>(CheckPointArray);
		var CinematiqueArray = FindObjectsOfTypeAll(typeof(SkipCinematique)) as SkipCinematique[];
		listCinematique = new List<SkipCinematique>(CinematiqueArray);
	}

	void Start()
	{
		SavingCheckPointFct(0);
		LoadInfoScene();

	}

	void LoadInfoScene()
	{
		var curCheckPoint = SaveManagerCheckpoint._Instance.GetCurCheckPointInScene(SceneId);
		var LastCinematiquePlayed = SaveManagerCheckpoint._Instance.GetCurCinematiqueInScene(SceneId);

		foreach (var it in listCinematique)
		{
			if (it.GetId() == LastCinematiquePlayed)
				it.CinematiqueWasPlayed();
		}
		if (curCheckPoint != 0)
			PlacePlayerOnCheckPoint(curCheckPoint);
	}

	void PlacePlayerOnCheckPoint(int idCheckPoint)
	{
		// place prefab and set all object
		listCheckPoint[idCheckPoint].LoadCheckPoint();
	}

	#region EventSave
	public void SavingCheckPointFct(int idCheckPoint)
	{
		SaveCheckPoint(SceneId, idCheckPoint);
	}

	public void SavingCinematiqueWasPlayed(int idCinematique)
	{
		SaveCinematique(SceneId, idCinematique);
	}
	#endregion
}
