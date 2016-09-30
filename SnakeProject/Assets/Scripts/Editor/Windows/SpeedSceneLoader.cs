//#define CHECKBOXES

using UnityEngine;
using UnityEditor;
using System.Collections;

public class SpeedSceneLoader : EditorWindow
{
	[MenuItem("File/Scene 0")]
	public static void Goto()
	{
		string scene = EditorBuildSettings.scenes[0].path;
		EditorApplication.OpenScene(scene);
	}

	[MenuItem("Window/SpeedSceneLoader")]
	static void InitSpeedSceneLoader()
	{
		SpeedSceneLoader window = (SpeedSceneLoader)EditorWindow.GetWindow(
		   typeof(SpeedSceneLoader),
		   false,
		   "Scene loader",
		   true
	   );

		window.init();
	}

	protected void init()
	{
		this.autoRepaintOnSceneChange = true;
		this.scroll = Vector2.zero;
	}

	private Vector2 scroll;
	public void OnGUI()
	{
		scroll = EditorGUILayout.BeginScrollView(scroll, false, true);
		foreach (var s in EditorBuildSettings.scenes)
		{
			if (this.filterPaths(s.path))
			{
				string[] splittedPath = s.path.Split(new char[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries);
				string name = splittedPath[splittedPath.Length - 1];
				name = name.Replace(".unity", "");

#if CHECKBOXES
                EditorGUILayout.BeginHorizontal();    
                EditorPrefs.SetBool("SCENE_CHECK_" + name, GUILayout.Toggle(EditorPrefs.GetBool("SCENE_CHECK_"+name), ""));
#endif
				Color old = GUI.color;

				if (Application.isPlaying)
				{
					if (name.ToLower().Equals(Application.loadedLevelName.ToLower()))
					{
						GUI.color = Color.yellow;
					}
				}
				else if (s.path.ToLower().Equals(EditorApplication.currentScene.ToLower()))
				{
					GUI.color = Color.green;
				}

				if (GUILayout.Button(name
#if CHECKBOXES
                    , GUILayout.Width(200)
#endif
))
				{
					if (Application.isPlaying)
					{
						//LevelLoader.Fade(name);
					}
					else
					{
						if(EditorApplication.SaveCurrentSceneIfUserWantsTo())
							EditorApplication.OpenScene(s.path);
					}

					Resources.UnloadUnusedAssets();
				}

				GUI.color = old;
#if CHECKBOXES
                EditorGUILayout.EndHorizontal();
#endif
			}
		}
		EditorGUILayout.EndScrollView();
	}

	public virtual bool filterPaths(string path)
	{
		return (true);
	}

	private bool wasPlaying = false;
	public void Update()
	{
		if (Application.isPlaying)
		{
			wasPlaying = true;
			this.Repaint();
		}
		else
		{
			if (wasPlaying)
			{
				wasPlaying = false;
				this.Repaint();
			}
		}
	}
}
