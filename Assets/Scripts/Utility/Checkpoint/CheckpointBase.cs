using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public int key = 01;

    private bool _isActive = false;
    private string checkpointKey = "Checkpoint Key";

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActive && other.transform.tag == "Player")
        {

            Checkpoint();


        }
    }


    private void Checkpoint()
    {
        Activate();
        SaveCheckpoint();


    }



    [NaughtyAttributes.Button]
    private void Activate() //necessario ativar emission no shader do objeto -- alterar a intensidade do HDR Color -- necessario criar um material especifico
    {

        meshRenderer.material.SetColor("_EmissionColor", Color.black);


    }

    [NaughtyAttributes.Button]
    private void Deactivate()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.red);
    }

    private void SaveCheckpoint()
    {
        /*if(PlayerPrefs.GetInt(checkpointKey, 0) > key)
            PlayerPrefs.SetInt(checkpointKey, key);*/

        CheckpointManager.Instance.SaveCheckpoint(key);

        SaveManager.Instance.SaveLastCheckpoint(key);

        _isActive = true;

    }

}
