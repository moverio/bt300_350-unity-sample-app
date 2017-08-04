/*###########################################################################################
#                                                                                      		#
# File:    RotationalVector.cs                                              	        	#
# Version: Release 01.00                                                               		#
# Date :   June 2017                                                             	   		#
# 				                                                                 	   		#
#                                                                                      		#
# Purpose – This is to demonstrate rotational vector input from controller					#
#																							#
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.		#
#           Do not attempt to run this script in earlier versions of Andriod.      		    #
#                                                                                      		#
# Copyright 2017 Seiko Epson Corporation. All rights reserved.   			         		#
#                                                                                      		#
###########################################################################################*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalVector : MonoBehaviour 
{

	// Use this for initialization
	private int TYPE_CONTROLLER_ROTATION_VECTOR=4;
	private float x, y, z;

	void Update () 
	{
		if (MoverioController.Instance.MoverioDevice == true) //Taking the input from controller and rotating the cube along with the movement of the controller.
		{
			//mapping controller rotation to the cube
			x = MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ROTATION_VECTOR) [1] * 180f;
			y = MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ROTATION_VECTOR) [2] * 180f;
			z = -MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ROTATION_VECTOR) [0] * 180f;
			transform.rotation = Quaternion.Euler (x, y, z);
		}
	}
}
