using UnityEngine;
using UnityEngine.UI;

public class InventoryGridSizeMaker : MonoBehaviour, GridSizeMaker
{
    [SerializeField]
    private float spacing = 10;
    [SerializeField]
    private int paddingLeft = 20;
    [SerializeField]
    private int paddingRight = 20;
    private RectTransform panel;
    private GridLayoutGroup gridLayoutGroup;
    private int columnSize;

    public void Init(RectTransform panel, GridLayoutGroup gridLayoutGroup, int columnSize)
    {
        this.panel = panel;
        this.gridLayoutGroup = gridLayoutGroup;
        this.columnSize = columnSize;
    }

    public void MakeGridSize()
    {
        float panelWidth = panel.rect.width;
        float totalPadding = paddingLeft + paddingRight;
        float totalSpacing = (columnSize - 1) * spacing;
        float cellSize = (panelWidth - totalPadding - totalSpacing) / columnSize;
        gridLayoutGroup.cellSize = Vector2.one * cellSize;
    }

}
