using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[InitializeOnLoad]
public class HierarchyHighlighter
{

	//static HierarchyHighlighter()
	//{
	//	EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItem_CB;
	//}

	//private static void HierarchyWindowItem_CB(int selectionID, Rect selectionRect)
	//{
	//	var o = EditorUtility.InstanceIDToObject(selectionID) as GameObject;
       
	//	if (o == null)
	//	{
	//		Debug.Log("o : " + o);
	//		return;

	//	}
	//	if (o != null)// && o.GetComponent<HierarchyHighlighterComponent>() != null)
	//	{
	//		HierarchyHighlighterComponent h = o.GetComponent<HierarchyHighlighterComponent>();
	//		if (h.highlight)
	//		{
	//			if (Event.current.type == EventType.Repaint)
	//			{
	//				GUI.backgroundColor = h.color;
	//				//doing this three times because once is kind of transparent.
	//				GUI.Box(selectionRect, "");
	//				GUI.Box(selectionRect, "");
	//				GUI.Box(selectionRect, "");
	//				GUI.backgroundColor = Color.white;
	//				EditorApplication.RepaintHierarchyWindow();
	//			}
	//		}
	//	}
	//}
}
