using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Control : MonoBehaviour
{
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            transform.position += input.normalized * 100 * Time.deltaTime;
        }
    }
}
