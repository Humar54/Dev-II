using UnityEngine;

public class Orange : Fruits
{
    [SerializeField] private bool _hasPeel;
    public override float GetEaten()
    {
        SquirtJuice();
        if (_hasPeel)
        {
            TasteBitter();
        }
        else
        {
            TasteSweet();
        }
        return base.GetEaten();
    }

    public void SquirtJuice()
    {
        Debug.Log("What a mess!");
    }
}
