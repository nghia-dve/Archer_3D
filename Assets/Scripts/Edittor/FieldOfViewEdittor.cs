using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*[CustomEditor (typeof (SearchPlayer))]
public class FieldOfViewEdittor : Editor
{
    private void OnSceneGUI()
    {
        SearchPlayer searchPlayer = (SearchPlayer)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(searchPlayer.transform.position, Vector3.up, Vector3.forward, 360, searchPlayer.viewRadius);
        Vector3 viewAngleA = searchPlayer.DirFromAngle(-searchPlayer.viewAngle / 2, false);
        Vector3 viewAngleB = searchPlayer.DirFromAngle(searchPlayer.viewAngle / 2, false);

        Handles.DrawLine(searchPlayer.transform.position, searchPlayer.transform.position + viewAngleA * searchPlayer.viewRadius);
        Handles.DrawLine(searchPlayer.transform.position, searchPlayer.transform.position + viewAngleB * searchPlayer.viewRadius);

        Handles.color = Color.red;

        foreach (var item in searchPlayer.VisibleTargets)
        {
            Handles.DrawLine(searchPlayer.transform.position, item.position);
        }
    }
}*/
