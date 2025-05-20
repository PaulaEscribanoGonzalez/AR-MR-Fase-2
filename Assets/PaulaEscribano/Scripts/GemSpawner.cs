using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;
    public ARPlaneManager planeManager;
    public int totalGems;

    public void SpawnGems()
    {
        int vertical = PlayerPrefs.GetInt("GemasVerticales", 0);
        int horizontal = PlayerPrefs.GetInt("GemasHorizontales", 0);
        totalGems = vertical + horizontal;
        GameManager.Instance.totalGems = totalGems;

        int placed = 0;
        foreach (var plane in planeManager.trackables)
        {
            if (placed >= totalGems) break;

            // Solo colocar si el plano es horizontal o vertical según el conteo
            if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp && horizontal > 0)
            {
                Vector3 pos = plane.center + new Vector3(Random.Range(-0.3f, 0.3f), 0.05f, Random.Range(-0.3f, 0.3f));
                Instantiate(gemPrefab, pos, Quaternion.identity);
                horizontal--;
                placed++;
            }
            else if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.Vertical && vertical > 0)
            {
                Vector3 pos = plane.center + new Vector3(Random.Range(-0.3f, 0.3f), 0.05f, Random.Range(-0.3f, 0.3f));
                Instantiate(gemPrefab, pos, Quaternion.identity);
                vertical--;
                placed++;
            }
        }
    }
}