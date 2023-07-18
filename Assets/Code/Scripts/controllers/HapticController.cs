using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticController : MonoBehaviour
{
    public static void SendHaptics(XRBaseController controller, float intensity, float duration)
    {
        controller.SendHapticImpulse(intensity, duration);
        Debug.Log("Control received haptic command");
    }

    //public static XRBaseController leftController;
    //public static XRBaseController rightController;

    //public float defaultIntensity = 0.2f;
    //public float defaultDuration = 0.5f;

    //public void SendHaptics()
    //{
    //    leftController.SendHapticImpulse(defaultIntensity, defaultDuration);
    //    rightController.SendHapticImpulse(defaultIntensity, defaultDuration);
    //}

    //public static void SendHaptics(float intensity, float duration)
    //{
    //    leftController.SendHapticImpulse(intensity, duration);
    //    rightController.SendHapticImpulse(intensity, duration);
    //}

    //public static void SendHaptics(bool isLeftController, float intensity, float duration)
    //{
    //    if (isLeftController)
    //    {
    //        leftController.SendHapticImpulse(intensity, duration);
    //    }
    //    else {
    //        rightController.SendHapticImpulse(intensity, duration);
    //    }
    //}




}
