using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeantTweenValue : MonoBehaviour
{
    [SerializeField] private Light _lightSource;
    [SerializeField] private float _delay;


    // Start is called before the first frame update
    void Start()
    {
        LeanTween.value(gameObject, 1, 0, _delay).setOnUpdate(UpdateLigthIntenisty).setOnComplete(ToggleLight);

    }

    private void UpdateLigthIntenisty(float lightIntensity)
    {
        _lightSource.intensity = lightIntensity;
    }


    private void ToggleLight()
    {
        if(_lightSource.intensity==1.0f)
        {
            LeanTween.value(gameObject, 1, 0, _delay).setEaseOutQuad().setOnUpdate(UpdateLigthIntenisty).setOnComplete(ToggleLight);
        }
        else
        {
            LeanTween.value(gameObject, 0, 1, _delay).setEaseOutQuad().setOnUpdate(UpdateLigthIntenisty).setOnComplete(ToggleLight);
        }
    }
}
