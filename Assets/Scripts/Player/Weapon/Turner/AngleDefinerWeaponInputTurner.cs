using UnityEngine;

public class AngleDefinerWeaponInputTurner : MonoBehaviour, Activator, InputTurner
{
    [SerializeField]
    private WeaponInputTurner weaponTurner;
    [SerializeField]
    private WeaponTypeDictionaryAngleDefiner weaponTypeDictionaryAngleDefiner;
    private Transform holdPoint;
    private WeaponType weaponType;

    public void Init(Transform holdPoint)
    {
        this.holdPoint = holdPoint;
        weaponTurner.Init(holdPoint);
    }

    public void Activate()
    {
        holdPoint.localRotation = Quaternion.Euler(Vector3.right * weaponTypeDictionaryAngleDefiner.DefineAngle(weaponType));
    }

    public void Turn(float input)
    {
        weaponTurner.Turn(input);
    }

    public WeaponType WeaponType
    {
        set => weaponType = value;
    }

}
