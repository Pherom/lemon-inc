using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTruck : MonoBehaviour
{
    private int driving = 0;
    [SerializeField]
    private GameObject truck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (driving != 0)
        {
            truck.transform.localPosition += Time.deltaTime * Vector3.back * 5 * driving;
        }
    }

    public void OnDriveRequest(string[] values)
    {
        switch (values[0])
        {
            case "forward":
                driving = 1;
                break;
            case "backwards":
                driving = -1;
                break;
        }
    }

    public void OnStopDrivingRequest(string[] values)
    {
        driving = 0;
    }
}
