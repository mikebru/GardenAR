using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatySphere : MonoBehaviour
{
    Rigidbody rigidbody;
    public float force = 50;
    public float Torque = 50;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Vector3 randomForce = new Vector3(Random.Range(-force, force), Random.Range(-force, force), Random.Range(-force, force));
        Vector3 randomTorque = new Vector3(Random.Range(-Torque, Torque), Random.Range(-Torque, Torque), Random.Range(-Torque, Torque));

        rigidbody.AddForce(randomForce);
        rigidbody.AddTorque(randomTorque);
    }


    private void OnMouseOver()
    {
        if(Input.GetMouseButton(0))
        {
            rigidbody.AddForce(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)));
        }
    }
}
