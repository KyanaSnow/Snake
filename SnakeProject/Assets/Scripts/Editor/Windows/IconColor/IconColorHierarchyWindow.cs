using UnityEngine;
using System.Collections;
using UnityEditor;

public class IconColorHierarchyWindow : EditorWindow
{
	[MenuItem("Window/Icon and Color Hierachy")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(IconColorHierarchyWindow));
	}

	public IconColorScriptableObject myScriptable;

	void OnGUI()
	{

	}
}
