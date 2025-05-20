using UnityEngine;

public class Gem : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource;
    private bool collected = false;

    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            collected = true;

            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            GameManager.Instance.CollectGem();
            Destroy(gameObject);
        }
    }
}