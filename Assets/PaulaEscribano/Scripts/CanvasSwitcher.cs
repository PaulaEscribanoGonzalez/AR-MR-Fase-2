using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvasPlanos;
    public GameObject canvasGemas;

    public void CambiarCanvas()
    {
        canvasPlanos.SetActive(false);
        canvasGemas.SetActive(true);
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("ScnSetup");
    }
}