using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollow : MonoBehaviour
{
    public Transform[] transforms;
    public float smoothTime = 1;
    public int currentIndex = 0;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveToTransform());

    }



    IEnumerator moveToTransform()
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * (1/smoothTime);

            transform.position = Vector3.SmoothDamp(transform.position, transforms[currentIndex].position, ref velocity, smoothTime);

            yield return null;

        }


        currentIndex += 1;

        if (currentIndex >= transforms.Length)
        {
            currentIndex = currentIndex - transforms.Length;
        }

        StartCoroutine(moveToTransform());
    }


}
