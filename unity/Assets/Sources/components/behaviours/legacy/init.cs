﻿using Assets.Src.net.kibotu.sandbox.unity.dragnslay.components.behaviours;
using UnityEngine;

public class init : MonoBehaviour
{
    public GameObject source;
    public GameObject target;

    public void OnGUI()
    {
        if (GUILayout.Button( "Move already, biatch!"))
        {
            var papership = source.transform.FindChild("Papership");
            var rotation = papership.GetComponent<Orbiting>();
            var move = papership.gameObject.AddComponent<MoveToTarget>();
            move.target = target;
            Destroy(rotation);
        }
    }
}
