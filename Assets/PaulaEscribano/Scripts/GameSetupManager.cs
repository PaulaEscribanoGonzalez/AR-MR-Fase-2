using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSetupManager : MonoBehaviour
{
    public Slider sliTime;
    public Slider sliGemVer;
    public Slider sliGemHor;
    public Toggle toggleOclusion;

    public void StartGame()
    {
        int time = Mathf.RoundToInt(sliTime.value);
        int gemVer = Mathf.RoundToInt(sliGemVer.value);
        int gemHor = Mathf.RoundToInt(sliGemHor.value);
        bool useOclusion = toggleOclusion.isOn;

        PlayerPrefs.SetInt("Time", time);
        PlayerPrefs.SetInt("GemasVerticales", gemVer);
        PlayerPrefs.SetInt("GemasHorizontales", gemHor);
        PlayerPrefs.SetInt("Oclusion", useOclusion ? 1 : 0);

        // Nombre exacto de la siguiente escena
        SceneManager.LoadScene("ScnTreasure");
    }
}