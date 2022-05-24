using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    protected IEnumerator MuerteProp() {
        yield return new WaitForSeconds(40);
        Destroy(this.gameObject);
        Destroy(this);
    }
}
