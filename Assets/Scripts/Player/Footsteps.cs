using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public void StepSound()
    {
        VolumeManager.instance.GetComponent<AudioManager>().PlayFootStepSound();
    }

}
