using UnityEngine;

public class DropdownResizer : MonoBehaviour
{
    public RectTransform dropdownTemplate;
    public float maxPaddingFromBottom = 50f;

    void Start()
    {
        float screenHeight = Screen.height;
        Vector3[] worldCorners = new Vector3[4];
        dropdownTemplate.GetWorldCorners(worldCorners);
        float bottomY = worldCorners[0].y;

        float spaceBelow = bottomY;
        float maxHeight = screenHeight - maxPaddingFromBottom - bottomY;

        dropdownTemplate.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Min(dropdownTemplate.rect.height, maxHeight));
    }
}
