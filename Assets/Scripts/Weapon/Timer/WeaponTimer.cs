using UnityEngine;

public class WeaponTimer : MonoBehaviour, Activator, Deactivator, Timer
{
    [SerializeField]
    private float maxTime = 1f;
    private float elapsedTime;
    private bool isStarted;
    private OnTimerCountListener onTimerCountListener;
    private OnTimerFinishListener onTimerFinishListener;

    public void Init(
        OnTimerCountListener onTimerCountListener,
        OnTimerFinishListener onTimerFinishListener)
    {
        this.onTimerCountListener = onTimerCountListener;
        this.onTimerFinishListener = onTimerFinishListener;
    }

    void Update()
    {
        if (isStarted)
        {
            elapsedTime -= Time.deltaTime;
            onTimerCountListener.OnTimerCount(elapsedTime);
        }
        if (elapsedTime < 0f)
        {
            OnTimerFinish();
        }
    }

    public void Activate()
    {
        isStarted = true;
        elapsedTime = maxTime;
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
        onTimerFinishListener.OnTimerFinish(elapsedTime);

        isStarted = false;
        elapsedTime = maxTime;
    }

    public float MaxTime => maxTime;
    
}
