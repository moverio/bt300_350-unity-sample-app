/*######################################################################################
#                                                                                      #
# File:    Magnetometer.cs                                                         	   #
# Version: Release 01.00                                                               #
# Date :   June 2017                                                             	   #
#    			                                                                 	   #
#                                                                                      #
# Purpose – To demonstrate the real compass using Magnetic field sensor.               #
#																					   #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.#
#           Do not attempt to run this script in earlier versions of Andriod.          #
#																					   #	
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                         #
#                                                                                      #
######################################################################################*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnetometer : MonoBehaviour 
{
	//Storing temporary Values of Magnitude and reference axis value of Magnatometer.
	private float _tempMagnitude,_tempXvalue,_value; 
	private float _damping = 10f;

	void Update()
	{


		if (MoverioController.Instance.MoverioDevice == true ) 
		{	
			//Using Moverio Controller's magnetic filed to point the compass towards real North.
			_value = new Vector3 (MoverioController.Instance.GetSensorData (2) [0], MoverioController.Instance.GetSensorData (2) [1], MoverioController.Instance.GetSensorData (2) [2]).magnitude; 

			_tempMagnitude= Mathf.Round ((Mathf.Clamp (_value, 40, 60) - 40f) * 9f);
			_tempXvalue = MoverioController.Instance.GetSensorData (4) [1] * 10;


			if ( MoverioController.Instance.GetSensorData (2) [0]>0 )    // Compass clockwise rotation with respect to reference axis. 
			{				
				
				Quaternion DestRot= Quaternion.Euler (0, 0, -_tempMagnitude);
				Quaternion smoothRot = Quaternion.Slerp(transform.rotation, DestRot, 1f - (Time.deltaTime*_damping));
				transform.rotation = smoothRot;			
			} 


			else if ( MoverioController.Instance.GetSensorData (2) [0]<0)  // Compass anticlockwise rotation with respect to reference axis.
			{
				
				Quaternion DestRot= Quaternion.Euler (0, 0, _tempMagnitude);
				Quaternion smoothRot = Quaternion.Slerp(transform.rotation, DestRot, 1f - (Time.deltaTime*_damping));
				transform.rotation = smoothRot;
			}

		}
	}

}
