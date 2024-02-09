
using UnityEngine;

public class WorkerDelegate : MonoBehaviour
{
    [SerializeField] private WorkType _workType;

    private delegate void WorkFunctionDelegate();
    private WorkFunctionDelegate _delegate;
    private enum WorkType
    {
        Mining,
        Logging,
        Farming,
    }

    private void Start()
    {
        switch (_workType)
        {
            case WorkType.Mining:
                _delegate = Mining;
                break;
            case WorkType.Logging:
                _delegate = Logging;
                break;
            case WorkType.Farming:
                _delegate = Farming;
                break;
        }
    }

    public void Work()
    {
        _delegate?.Invoke();
    }

    public void Logging()
    {
        Debug.Log("Worker is Logging");
    }

    public void Farming()
    {
        Debug.Log("Worker is Farming");
    }

    public void Mining()
    {
        Debug.Log("Worker is Mining");
    }
}
