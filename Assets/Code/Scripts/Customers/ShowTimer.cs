using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject timerPrefab;
    [SerializeField]
    private int minTimeInSeconds;
    [SerializeField]
    private int maxTimeInSeconds;

    public void DisplayTimer()
    {
        GameObject timer = Instantiate(timerPrefab, transform.position + Vector3.up * gameObject.transform.localScale.y * 3.5f, gameObject.transform.rotation);
        timer.transform.SetParent(transform);
        timer.GetComponentInChildren<Timer>().seconds = Random.Range(minTimeInSeconds, maxTimeInSeconds + 1);
    }
}
