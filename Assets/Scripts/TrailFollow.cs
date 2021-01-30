using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollow : MonoBehaviour
{
    public GameObject PathParent;
    public Transform[] transforms;
    public float smoothTime = 1;
    public int currentIndex = 0;
    private Vector3 velocity = Vector3.zero;

    public bool updateInEditor = true;

    // Start is called before the first frame update
    void Start()
    {

        if(PathParent != null)
        {
            transforms = PathParent.GetComponentsInChildren<Transform>();
        }

        StartCoroutine(moveToTransform());

    }

    private void OnDrawGizmos()
    {
        if (updateInEditor == true)
        {
            if (PathParent != null && transforms.Length > 0)
            {
                transforms = PathParent.GetComponentsInChildren<Transform>();
               // StartCoroutine(moveToTransform());

            }
        }
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
