using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColour : MonoBehaviour
{
    public MeshRenderer meshRender;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Header("Settup")]
    public Color color = Color.red;
    public float duration = .2f;

    private Tween _currTween;

    [Space]
    public string colorParameter = "_EmissionColor";

    private void OnValidate()
    {
        if (meshRender == null) meshRender = GetComponent<MeshRenderer>();
        if (skinnedMeshRenderer == null) skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    /* private void Start() old checking, only mesh renderer
     {
         _defaultColor = meshRender.material.GetColor("_EmissionColor");
     }*/


    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(meshRender != null && !_currTween.IsActive())
            _currTween = meshRender.material.DOColor(color, colorParameter, duration).SetLoops(2, LoopType.Yoyo);
        
        if(skinnedMeshRenderer != null && !_currTween.IsActive())
            _currTween = skinnedMeshRenderer.material.DOColor(color, colorParameter, duration).SetLoops(2, LoopType.Yoyo);


    }



}
