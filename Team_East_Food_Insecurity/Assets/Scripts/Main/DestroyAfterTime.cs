using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 1;
    [SerializeField] bool activateOnEnable;
    [SerializeField] bool turnOffInstead;

    void OnEnable()
    {
        if (activateOnEnable)
            StartCoroutine(nameof(DelayedDestroy));
    }

    void OnDisable() => StopCoroutine(nameof(DelayedDestroy));

    public void DestroyAfterDelay() => StartCoroutine(nameof(DelayedDestroy));

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSecondsRealtime(timeToDestroy);
        if (!turnOffInstead)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
    }
}