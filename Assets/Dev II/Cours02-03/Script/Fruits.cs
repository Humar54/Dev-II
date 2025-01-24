using UnityEngine;

public class Fruits : MonoBehaviour
{
    [SerializeField] protected float _vitamineCContent;

    public virtual float GetEaten()
    {
        return _vitamineCContent;
    }

    protected void TasteSweet()
    {
        Debug.Log("Hum Yum!");
    }

    protected void TasteBitter()
    {
        Debug.Log("Yuck!");
    }
}
