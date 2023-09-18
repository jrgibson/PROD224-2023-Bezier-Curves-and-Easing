using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayInterpolation : MonoBehaviour {
    public bool  useTime  = false;
    [Range(0.125f,8)]
    public float duration = 1;

    public bool useEasing      = false;
    [Range(1,8)]
    public int  easingExponent = 2;
    [Range(-1,1)]
    public float sinMultiple = 0;
    
    
    [Range( 0, 1 )]
    public float uInt = 0;
    [Range(-1,2)]
    public float uExt = 0;
    public List<Transform> transforms;

    public Color c0, c1;

    private Material mat;
    
    void Start() {
        mat = GetComponent<Renderer>().material;
    }

    void Update() {
        // Determine the u value
        float u = uInt + uExt;
        if ( useTime ) {
            // Pay attention to Time
            // u = (Time.time / duration) % 1f;
            u = Mathf.PingPong(Time.time / duration, 1f);
        }

        // Mess with the u value
        if ( useEasing ) {
            // u = u * u; // Ease In (Quadratic curve)
            // u = 1 - ((1 - u) * (1 - u)); // Ease Out
            u = u + sinMultiple * Mathf.Sin( 2 * Mathf.PI * u ); // Sin Easing
            u = Mathf.Pow( u, easingExponent ); // Ease In
        }

        // Convert all of the Transforms into Vector3 points
        Vector3[] points = new Vector3[transforms.Count];
        for (int i = 0; i < transforms.Count; i++) {
            points[i] = transforms[i].position;
        }

        // Interpolate and Extrapolate
        transform.position = InterpolateArray1D( points, u );

        mat.color = (1 - u) * c0 + u * c1;
    }

    Vector3 InterpolateArray( Vector3[] points, float u ) {
        // Create a 2D Vector3[] to interpolate over
        Vector3[,] arr = new Vector3[points.Length, points.Length];
        int row = points.Length - 1;
        // Copy the points into the last row of the array
        for (int i = 0; i < points.Length; i++) {
            arr[row, i] = points[i];
        }
        // Start interpolating downward
        for (; row > 0; row--) {
            for (int col = 0; col < row; col++) {
                arr[row - 1, col] = (1 - u) * arr[row, col] + u * arr[row, col + 1];
            }
        }
         
        // Return the final interpolated value
        return arr[0, 0];
    }
    
    Vector3 InterpolateArray1D( Vector3[] points, float u ) {
        // Create a 2D Vector3[] to interpolate over
        Vector3[] arr = new Vector3[points.Length * points.Length];
        int row = points.Length - 1;
        int len = points.Length;
        // Copy the points into the last row of the array
        for (int i = 0; i < points.Length; i++) {
            arr[row*len + i] = points[i];
        }
        // Start interpolating downward
        for (; row > 0; row--) {
            for (int col = 0; col < row; col++) {
                arr[(row - 1)*len + col] 
                    = (1 - u) * arr[row*len + col] + u * arr[row*len + col + 1];
            }
        }
         
        // Return the final interpolated value
        return arr[0];
    }
}


// The 2D version
// [ [ p0123,   0,      0,      0 ]
//   [ p012,    p123,   0,      0 ]
//   [ p01,     p12,    p23,    0 ]
//   [ p0,      p1,     p2,     p3 ] ]

// The 1D version
// [ p0123, 0, 0, 0,     p012, p123, 0, 0,  p01, p12, p23, 0,    p0, p1, p2, p3 ] 