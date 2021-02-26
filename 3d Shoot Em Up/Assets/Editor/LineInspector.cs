using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof (line))]
public class LineInspector : Editor {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnSceneGUI()
    {
        line l = target as line;

        Transform handleTransform = l.transform;
        Quaternion handleRotation =Tools.pivotRotation == PivotRotation.Local ?
            handleTransform.rotation : Quaternion.identity;

        Vector3 p0 = handleTransform.TransformPoint(l.p0);
        Vector3 p1 = handleTransform.TransformPoint(l.p1);

        EditorGUI.BeginChangeCheck();
        p0 = Handles.DoPositionHandle(p0, handleRotation);
        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(l, "Move Point");
            EditorUtility.SetDirty(l);
            l.p0 = handleTransform.InverseTransformPoint(p0);
        }
        EditorGUI.BeginChangeCheck();
        p1 = Handles.DoPositionHandle(p1, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(l, "Move Point");
            EditorUtility.SetDirty(l);
            l.p1 = handleTransform.InverseTransformPoint(p1);
        }



        Handles.color = Color.white;
        Handles.DrawLine(p0, p1);
        //Handles.DoPositionHandle(p0, handleRotation);
       // Handles.DoPositionHandle(p1, handleRotation);


        
    }
}
