using UnityEngine;

public class WeaponTimer : MonoBehaviour, Activator, Deactivator, Timer
{
    [SerializeField]
    private float maxTime = 1f;
    private float elapsedTime;
    private bool isStarted;
    private OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener;
    private OnTimerFinishListener onTimerFinishListener;

    public void Init(
        OnWeaponProgressBarChangeValueListener onWeaponProgressBarChangeValueListener,
        OnTimerFinishListener onTimerFinishListener)
    {
        this.onWeaponProgressBarChangeValueListener = onWeaponProgressBarChangeValueListener;
        this.onTimerFinishListener = onTimerFinishListener;
    }

    void Update()
    {
        if (isStarted)
        {
            elapsedTime += Time.deltaTime;
            onWeaponProgressBarChangeValueListener.OnWeaponProgressBarChangeValue(elapsedTime / maxTime);
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
