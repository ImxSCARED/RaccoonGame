using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMPASS : MonoBehaviour
{
    public GameObject targetObject;

    // Update is called once per frame
    void Update()
    {
        // get worldspace coordinates of target
        Vector3 target = targetObject.transform.position;
        // Vector3 target = transform.position + Vector3.forward; // (to make needle point north)

        // convert to local coordinate space of compass body
        Vector3 relativeTarget = transform.parent.InverseTransformPoint(target);

        // determine needle rotation with atan2
        float needleRotation = Mathf.Atan2(relativeTarget.x, relativeTarget.z) * Mathf.Rad2Deg;

        // apply needle rotation
        transform.localRotation = Quaternion.Euler(0, needleRotation, 0);
    }
}
