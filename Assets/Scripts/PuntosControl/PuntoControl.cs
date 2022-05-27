using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoControl : MonoBehaviour
{
    private TrackCheckpoints track;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {

            track.CochePasaPuntoControl(this,other.transform);
        }
    }

    public void SetTrack(TrackCheckpoints t) {
        this.track = t;
    }
}
