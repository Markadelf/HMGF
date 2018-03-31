using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

    public float speed = 5;
    //The camera
    public GameObject head;
    //The rig
    public GameObject rig;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Left Hand  X = Axis 1 y = Axis 2
        //Right Hand x = Axis 4 y = Axis 5

        //Will test and implement!
        float thrust = Input.GetAxis("Vertical");
        if (head != null)
        {
            if (thrust != 0)
            {
                Vector3 direction = head.transform.forward;
                if (direction.x == 0 && direction.z == 0)
                {
                    direction = -head.transform.up;
                }
                direction.y = 0;
                direction.Normalize();
                if (thrust > 0)
                {
                    transform.position += direction * Time.deltaTime * speed;
                }
                if (thrust < 0)
                {
                    transform.position -= direction * Time.deltaTime * speed;
                }
            }
            if (rig != null)
            {
                Vector3 change = (transform.position - head.transform.position);
                //change.y = 0;
                //transform.position -= change;
                rig.transform.position += (change);
            }
        }
        else
        {
            if (thrust > 0)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
            if (thrust < 0)
            {
                transform.position -= transform.forward * Time.deltaTime * speed;
            }
        }

		if (Input.GetAxis("Horizontal") > 0) 
		{
			transform.Rotate(transform.up * 70.0f * Time.deltaTime);
		}
		if (Input.GetAxis("Horizontal") < 0) 
		{
			transform.Rotate(-transform.up * 70.0f * Time.deltaTime);
		}
	}
}
