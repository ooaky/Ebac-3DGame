using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Core.Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
    public PostProcessVolume ppVolume;
    [SerializeField] private Vignette _vignette;

    public float duration = 1f;

    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());
    }


    IEnumerator FlashColorVignette()
    {
        Vignette temp;

        if (ppVolume.profile.TryGetSettings<Vignette>(out temp)) //out pega a variavel criada e passa a referencia para dentro da função, sem criar uma nova
                                                                 //se mantem atualizado
        {
            _vignette = temp;

        }

        ColorParameter c = new ColorParameter();

        float time = 0;
        while(time < duration)
        {
            //c.value = Color.red;
            c.value = Color.Lerp(Color.black, Color.red, time / duration);

            time += Time.deltaTime;

            _vignette.color.Override(c);
            // _vignette.color eg um Color Parameter

            yield return new WaitForEndOfFrame();
        }

    }



}
