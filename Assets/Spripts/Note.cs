using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{

    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        pos.z -= 10 * Time.deltaTime;
        myTransform.position = pos;
        if (this.transform.position.z < -2.5f)
        {
            Destroy(this.gameObject);
        }
    }
}