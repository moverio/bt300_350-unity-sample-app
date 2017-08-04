/*######################################################################################
#                                                                                      #
# File:    CameraAdjustment.cs                                                    	   #
# Version: Release 01.00                                                               #
# Date :   June 2017                                                             	   #
#                                                                               	   #
#                                                                                      #
# Purpose – To demonstrate the Gyroscopic values by switching between planes.          #
#                                                                                      #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.#
#           Do not attempt to run this script in earlier versions of Andriod.          #
#                                                                                      #
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                         #
#                                                                                      #
######################################################################################*/
using UnityEngine;
using System.Collections;

public class CameraAdjustment: MonoBehaviour
{

	#region DecraledVariables
	public string TargetObject;

	[SerializeField]
	float height;

	private Vector3 _camPos;
	private RaycastHit _rayHit;

	#endregion

    void Start()
    {
		Input.gyro.enabled = true;      //Enabling the headset gyroscope.
    
    }

    void LateUpdate()
    {
         transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);  //Rotation of camera with respect to gyroscope.
       
        _camPos = transform.position;

    }
	public bool rayAlgo()     //using raycasting for detection of the object in front of the eyesight of MoverioCameracontroller.
    {
		
        Vector3 dir = transform.forward;
		if (Physics.Raycast (_camPos, dir,out _rayHit, height))
		{
			TargetObject = _rayHit.transform.tag;
			return true;
		}
        else 

			return false;
    }
}