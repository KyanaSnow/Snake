using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveManagerCheckpoint : MonoBehaviour
{
	public static SaveManagerCheckpoint _Instance;

	[SerializeField] private List<string> ListScene;

	private int _curSceneSavePoint;
	private int _curSavePoint;
	private int _curSceneCinematique;
	private int _curCinematique;

	void Awake()
	{
		if (_Instance == null)
			_Instance = this;
		else if (_Instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

		LoadingStoryFct();

		if (SceneManagerCheckpoint._Instance != null)
		{
			SceneManagerCheckpoint._Instance.SaveCheckPoint += SavingCheckPointFct;
			SceneManagerCheckpoint._Instance.SaveCinematique += SavingCinematique;
		}
	}

	public void LoadingStoryFct()
	{
		//load file
	}

	public void ClearStoryFct()
	{
		_curSceneSavePoint = 0;
		_curSceneCinematique = 0;
		_curSavePoint = 0;
		_curCinematique = 0;

		//Save in file
	}

	#region CheckPoint
	public void SavingCheckPointFct(int idScene, int idCheckPoint)
	{
		//save in file if new checkpoint
		if (idScene >= _curSceneSavePoint && idCheckPoint > _curSavePoint)
		{
			_curSceneSavePoint = idScene;
			_curSavePoint = idCheckPoint;
			//save in file
		}
	}

	public int GetCurCheckPointInScene(int curScene)
	{
		if (curScene > _curSceneSavePoint)
			return 0;
		else
			return _curSavePoint;
	}
	#endregion

	#region Cinematique
	public void SavingCinematique(int idScene, int idCinematique)
	{
		//save in file the cinematique if new
		if (idScene >= _curSceneCinematique && idCinematique > _curCinematique)
		{
			_curSceneCinematique = idScene;
			_curCinematique = idCinematique;
			//save in file
		}
	}

	public int GetCurCinematiqueInScene(int curScene)
	{
		if (curScene > _curSceneCinematique)
			return 0;
		else
			return _curCinematique;
	}
	#endregion


}
