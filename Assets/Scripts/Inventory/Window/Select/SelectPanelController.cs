using UnityEngine;

public class SelectPanelController : MonoBehaviour
{
    [SerializeField]
    private SelectSlotController selectSlotController;

    public void Init(string name)
    {
        selectSlotController.SetNameText(name);
    }

    public void SetWeaponText(string name)
    {
        selectSlotController.SetNameText(name);
    }
    
}
