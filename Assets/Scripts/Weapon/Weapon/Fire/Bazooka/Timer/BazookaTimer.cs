using UnityEngine;

public class BazookaTimer : MonoBehaviour, Activator, Deactivator, Timer
{
    [SerializeField]
    private float maxTime = 5f;
    private float elapsedTime;
    private bool isStarted;
    private OnTimerFinishListener onTimerFinishListener;

    public void Init(OnTimerFinishListener onTimerFinishListener)
    {
        this.onTimerFinishListener = onTimerFinishListener;
    }

    void Update()
    {
        if (isStarted)
        {
            elapsedTime += Time.deltaTime;
        }
        if (elapsedTime >= maxTime)
        {
            OnTimerFinish();
        }
    }

    public void Activate()
    {
        isStarted = true;
        elapsedTime = 0f;
    }

    public void Deactivate()
    {
        if (isStarted)
        {
            OnTimerFinish();
        }
    }

    public float CountTime()
    {
        return elapsedTime;
    }

    void OnTimerFinish()
    {
        isStarted = false;
        onTimerFinishListener.OnTimerFinish(elapsedTime);
        elapsedTime = 0f;
    }

    public float MaxTime => maxTime;
    
}
