using UnityEngine;

public class BodyController : MonoBehaviour
{
    [SerializeField]
    private new Renderer renderer;

    public Renderer Renderer
    {
        get => renderer;
        set => renderer = value;
    }
    
}
