using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSC_Camera : MonoBehaviour
{

    private OSC osc;
    public Vector3 startRotation;

    private float x = 0;
    private float y = 0;


    // Start is called before the first frame update
    void Start()
    {

        startRotation = this.transform.rotation.eulerAngles;

        osc = GetComponent<OSC>();

        osc.SetAddressHandler("/CubeXYZ", OnReceiveXYZ);
        osc.SetAddressHandler("/Tilt", OnReceiveX);
        osc.SetAddressHandler("/Pan", OnReceiveY);
    }

       

    void OnReceiveXYZ(OscMessage message)
    {
        float x = message.GetFloat(0);
        float y = message.GetFloat(1);
        float z = message.GetFloat(2);

        transform.rotation = Quaternion.Euler(new Vector3(x, y, z));
    }

    void OnReceiveX(OscMessage message)
    {
        x = message.GetFloat(0);

        transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, 0));

    }

    void OnReceiveY(OscMessage message)
    {
        y = message.GetFloat(0);

        transform.rotation = Quaternion.Euler(startRotation + new Vector3(x, y, 0));

    }


}
