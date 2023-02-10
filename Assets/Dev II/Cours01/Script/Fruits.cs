using UnityEngine;

public class Fruits : MonoBehaviour
{
    public float _vitamineCContent;

    public virtual float GetEaten()
    {
        return _vitamineCContent;
    }

    public void TasteSweet()
    {
        Debug.Log("Hum Yum!");
    }

    public void TasteBitter()
    {
        Debug.Log("Yuck!");
    }
}
