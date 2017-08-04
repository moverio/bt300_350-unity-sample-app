/*#########################################################################################################
#                                                                                                         #
# File:    AcclerateScript.cs                                                    	                      #
# Version: Release 01.00                                                                                  #
# Date :   June 2017                                                             	                      #
#                                                                               	                      #
#                                                                                                         #
# Purpose – To Demonstrate working of Combined inputs of Accelerometer & Gyroscope from the Headset.      #
#                                                                                                         #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.                   #
#           Do not attempt to run this script in earlier versions of Andriod.                             #
#                                                                                                         #
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                                            #
#                                                                                                         #
#########################################################################################################*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AccelerateScript: MonoBehaviour 
{

	#region DecraledVariables

	[SerializeField]
    float speed;

	[SerializeField]
	string Target;

    private Rigidbody _rb;
	private CameraAdjustment _cam;
	private int TYPE_HEADSET_ACCELEROMETER = 0;
    private Vector3 _initial;

	#endregion
           

    void Start()
    {
        _initial = transform.position; //Recording initial transformation.
        _rb = GetComponent<Rigidbody>();//Accessing rigidbody component.
		_cam = FindObjectOfType(typeof(CameraAdjustment)) as CameraAdjustment; //Position view based on gyroscope inputs from CameraAdjustment script.
    }
    // Update is called once per frame
    void Update ()
	{
		if (MoverioController.Instance.MoverioDevice == true)   //Checking current device.
		{

			if (transform.position.y < -8)                
			{
				transform.position = _initial;
			}
			if (_cam.rayAlgo ()) 
			{
				if (Target == _cam.TargetObject) 
				{
					if (Target == "first") //Accessing the Sensor Data
					{
						Vector3 movement = new Vector3 (MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [0], 0.0f, -MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [2]);  //Accessing the values of the accelerometer from headset.
						_rb.AddForce (movement * speed);  
					} 
					else 
					{
						Vector3 movement = new Vector3 (MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [2], 0.0f, MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [0]);  //Accessing the values of the accelerometer from headset.
						_rb.AddForce (movement * speed * -1f);
					}
					
				}
			}
      
		}
	}
}
