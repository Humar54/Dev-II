
using UnityEngine;

public class Apple : Fruits
{
    public override float GetEaten()
    {   
        TasteSweet();
        EmitCrunchNoise();

        return base.GetEaten();
    }

    private void EmitCrunchNoise()
    {
        Debug.Log("Crunch");
    }
}
