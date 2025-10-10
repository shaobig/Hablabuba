using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotRemover : MonoBehaviour, Remover<List<WeaponSlotController>>
{
    [SerializeField]
    private GameObjectRemover gameObjectRemover;

    public void Remove(List<WeaponSlotController> slotList)
    {
        slotList.ForEach(slot => gameObjectRemover.Remove(slot.gameObject));
        slotList.Clear();
    }

}
