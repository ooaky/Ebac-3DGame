using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAbilityBase : MonoBehaviour
{
    protected Player player;

    protected Inputs inputs;

    private void OnValidate()
    {
        if (player == null) player = GetComponent<Player>();
    }

    private void Start()
    {
        inputs = new Inputs();
        inputs.Enable();




        Init();
        
        OnValidate();

        RegisterListener();
    }


    private void OnEnable()
    {
        if (inputs != null) inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }

    private void OnDestroy()
    {
        RemoveListener();
    }

    protected virtual void Init()
    {

    }

    protected virtual void RegisterListener() 
    { 
    
    }

    protected virtual void RemoveListener() 
    { 

    }


}
