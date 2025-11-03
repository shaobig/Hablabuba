using UnityEngine;

public class AimController : MonoBehaviour, AimTaker
{
    [SerializeField]
    private Transform aimPoint;
    private OnAimTakenListener onAimTakenListener;

    public void Init(OnAimTakenListener onAimTakenListener)
    {
        this.onAimTakenListener = onAimTakenListener;
    }

    public void TakeAim()
    {
        Debug.Log("Allo, I'm here!");
        onAimTakenListener.OnAimTaken(aimPoint);
    }
    
}
