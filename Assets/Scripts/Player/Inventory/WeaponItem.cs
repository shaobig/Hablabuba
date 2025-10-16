using UnityEngine;

public class WeaponItem
{
    private Weapon weapon;
    private Sprite sprite;
    private GameObject prefab;
    private int amount;

    public WeaponItem(Weapon weapon, Sprite sprite, GameObject prefab, int amount)
    {
        this.weapon = weapon;
        this.sprite = sprite;
        this.prefab = prefab;
        this.amount = amount;
    }

    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    public Sprite Sprite
    {
        get => sprite;
        set => sprite = value;
    }

    public GameObject Prefab
    {
        get => prefab;
        set => prefab = value;
    }

    public int Amount
    {
        get => amount;
        set => amount = value;
    }
    
}
