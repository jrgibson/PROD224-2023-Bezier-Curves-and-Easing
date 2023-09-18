using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolator : MonoBehaviour {
    public Transform t0, t1, t2, t3;

    [Range( 0, 1 )]
    public float uInt = 0;
    [Range(-1,2)]
    public float uExt = 0;
    
    
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        float u = uInt + uExt;
        Vector3 p0 = t0.position;
        Vector3 p1 = t1.position;
        Vector3 p2 = t2.position;
        Vector3 p3 = t3.position;

        Vector3 p01 = (1 - u) * p0 + u * p1;
        Vector3 p12 = (1 - u) * p1 + u * p2;
        Vector3 p23 = (1 - u) * p2 + u * p3;
        Vector3 p012 = (1 - u) * p01 + u * p12;
        Vector3 p123 = (1 - u) * p12 + u * p23;
        Vector3 p0123 = (1 - u) * p012 + u * p123;
        
        transform.position = p0123;
    }
}
