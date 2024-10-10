using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    [Header("Movement")]
    public float speed;
    public Vector2 friction = new Vector2(.1f, 0);


    [Header("Running")]
    public float speedRun;

    [Header("Jump")]
    public float jumpHeight;

    [Header("Animation")]
    public string moveBool = "Run";
   
}
