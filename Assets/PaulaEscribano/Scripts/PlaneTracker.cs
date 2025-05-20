using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class PlaneTracker : MonoBehaviour
{
    public ARPlaneManager planeManager;

    public GameObject planeCountTextHor;  // GameObject con componente Text
    public GameObject planeCountTextVer;  // GameObject con componente Text
    public GameObject instantiateButton;  // Bot�n que se activa al detectar suficientes planos

    private int targetHorizontal;
    private int targetVertical;

    void Start()
    {
        targetHorizontal = PlayerPrefs.GetInt("GemasHorizontales", 1);
        targetVertical = PlayerPrefs.GetInt("GemasVerticales", 1);
    }

    void Update()
    {
        int countHor = 0;
        int countVer = 0;

        foreach (var plane in planeManager.trackables)
        {
            if (!plane.gameObject.activeSelf)
                continue;

            // Clasificamos el plano por su alineaci�n
            if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp ||
                plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalDown)
            {
                countHor++;
            }
            else if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.Vertical)
            {
                countVer++;
            }
        }

        // Accedemos al componente Text dentro del GameObject
        if (planeCountTextHor != null)
            planeCountTextHor.GetComponent<Text>().text = $"Horizontales: {countHor}/{targetHorizontal}";

        if (planeCountTextVer != null)
            planeCountTextVer.GetComponent<Text>().text = $"Verticales: {countVer}/{targetVertical}";

        // Activamos bot�n si ya se detectaron suficientes planos
        if (countHor >= targetHorizontal && countVer >= targetVertical)
        {
            instantiateButton.SetActive(true);
        }
        else
        {
            instantiateButton.SetActive(false);
        }
    }
}
