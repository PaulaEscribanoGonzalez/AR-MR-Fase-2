using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class OclusionController : MonoBehaviour
{
    public AROcclusionManager occlusionManager;

    void Start()
    {
        bool useOclusion = PlayerPrefs.GetInt("Oclusion", 0) == 1;

        if (occlusionManager != null)
        {
            occlusionManager.requestedEnvironmentDepthMode =
                useOclusion ?
                UnityEngine.XR.ARSubsystems.EnvironmentDepthMode.Medium :
                UnityEngine.XR.ARSubsystems.EnvironmentDepthMode.Disabled;
        }
    }
}
