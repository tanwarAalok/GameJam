using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
public class PostProcessController : MonoBehaviour
{
    GameManager gameManager;
    public static PostProcessController instance;
    Volume postProcessVolume;
    Vignette vignette;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        postProcessVolume = GetComponent<Volume>();
        instance = this;
    }
    public void VignetteColor()
    {
       if(postProcessVolume.profile.TryGet<Vignette>(out vignette))
       {
            vignette.color.value = new Color(1, 0, 0);
            if(!gameManager.GetPlayerDeadState())
            {
                StartCoroutine(OrignalVignetteColor());
            }
       }
    }
    IEnumerator OrignalVignetteColor()
    {
        yield return new WaitForSeconds(0.5f);
        vignette.color.value = new Color(0, 0, 0);
    }
    public void VignetteIntensity(float intensity)
    {
        vignette.intensity.value = Mathf.Min(intensity, 1f);
        if(!gameManager.GetPlayerDeadState())
        {
            StartCoroutine(OrignalVignetteIntensity());
        }
    }
    IEnumerator OrignalVignetteIntensity()
    {
        yield return new WaitForSeconds(0.5f);
        vignette.intensity.value = 0.3f;
    }
}
