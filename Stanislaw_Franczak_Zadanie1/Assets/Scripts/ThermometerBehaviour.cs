using TMPro;
using UnityEngine;

public class ThermometerBehaviour : MonoBehaviour
{
    [Header("Tekst wyœwietlnany na sprite")]
    [SerializeField] TextMeshProUGUI text;

    // Raycast pozwoli nam na odczytanie jaka temperatura panuje na obszarze pod termometrem
    RaycastHit hit;
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            text.SetText(hit.transform.gameObject.GetComponent<TemperatureFieldScript>().temperature.ToString());
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            text.SetText("Brak danych");
        }
    }
}
