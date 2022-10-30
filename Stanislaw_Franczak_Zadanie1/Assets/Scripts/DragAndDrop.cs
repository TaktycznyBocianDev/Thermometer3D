using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset; //Zapobiegnie "skakaniu" termometra do kursora podczas naciskania na niego
    private Camera cameraMain;

    private void Awake()
    {
        cameraMain = Camera.main;
    }

    private void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = cameraMain.WorldToScreenPoint(transform.position).z;
        return cameraMain.ScreenToWorldPoint(mouseScreenPos);

    }
}
