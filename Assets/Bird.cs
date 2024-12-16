using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 initialPosition;
    private bool isDragging = false;

    public LineRenderer slingshotLine; // Reference to the LineRenderer
    public Transform slingshotBase;   // The base of the slingshot
    public float launchPower = 500f; // Multiplier for the launch force

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        rb.isKinematic = true; // Bird stays static until launched
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
            UpdateSlingshotLine();
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        Vector3 launchDirection = initialPosition - transform.position;
        rb.isKinematic = false;
        rb.AddForce(launchDirection * launchPower);
        ResetSlingshotLine();
    }

    private void UpdateSlingshotLine()
    {
        if (slingshotLine != null)
        {
            slingshotLine.positionCount = 2;
            slingshotLine.SetPosition(0, slingshotBase.position); // Static base
            slingshotLine.SetPosition(1, transform.position);     // Dragged position
        }
    }

    private void ResetSlingshotLine()
    {
        if (slingshotLine != null)
        {
            slingshotLine.positionCount = 2;
            slingshotLine.SetPosition(0, slingshotBase.position);
            slingshotLine.SetPosition(1, slingshotBase.position); // Reset to base
        }
    }
}
