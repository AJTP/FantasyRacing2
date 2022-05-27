using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    bool ok = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ok = !ok;
            transform.GetChild(0).gameObject.SetActive(ok);
        }
    }
}
