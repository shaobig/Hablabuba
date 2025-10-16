using UnityEngine;

public class BazookaTimer : MonoBehaviour, Activator, Deactivator, Timer, Reseter
{
    private const float RESET_TIME = 0f;

    [SerializeField]
    private float maxTime = 5f;
    private bool isStarted;
    private float elapsedTime;
    private OnTimerFinishedListener onTimerFinishedListener;

    public void Init(OnTimerFinishedListener onTimerFinishedListener)
    {
        this.onTimerFinishedListener = onTimerFinishedListener;
    }

    public void Activate()
    {
        isStarted = true;
    }

    public void Deactivate()
    {
        isStarted = false;
    }

    public void CountTime()
    {
        elapsedTime += Time.deltaTime;
    }

    public void Reset()
    {
        elapsedTime = RESET_TIME;
    }

    public float MaxTime => maxTime;
    
}
