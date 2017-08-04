/*########################################################################################
#                                                                                         #
# File:    Gyroscope.cs                                                    			      #
# Version: Release 01.00                                                                  #
# Date :   June 2017                                                             	      #
#                                                                                	      #
#                                                                                         #
# Purpose – To demonstrate see-through capability as well as the gyroscopic values.       #
#			The virtual Earth can be observed along with the real object around the users.#
#     																				      #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.   #
#           Do not attempt to run this script in earlier versions of Andriod.         	  #
#                                                                                         #
# Copyright 2017 Seiko Epson Corporation. All rights reserved.            		          #
#                                                                                         #
#########################################################################################*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyroscope : MonoBehaviour 
{

	#region DecraledVariables
	// Use this for initialization
	[SerializeField]
	Text TitleText;

	[SerializeField]
	Toggle tglBtn;

	[SerializeField]
	GameObject camera;

	[SerializeField]
	GameObject earthObj;

	[SerializeField]
	float speed;


	private int TYPE_CONTROLLER_GYROSCOPE = 3;

	#endregion

	void Update () 
	{
		if (MoverioController.Instance.MoverioDevice == true)
		{
			
	

		if   (tglBtn.isOn == true) //switching between head tracking and controller tracking
		{                     
			
			camera.GetComponent<HeadTrackingAR>().enabled = false;  //Disabling the headset gyroscope.
				TitleText.text = "GYRO Controller : " + Mathf.Round (MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_GYROSCOPE) [0]).ToString () + ", " +
			", " + Mathf.Round (MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_GYROSCOPE) [1]).ToString () + ", " +
			", " + Mathf.Round (MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_GYROSCOPE) [2]).ToString ();

			camera.transform.Rotate (-MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_GYROSCOPE) [0] * 5f, -MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_GYROSCOPE) [1] * 5f, 0); //enabling the Controller gyroscope.

		}
		else 
		{
			camera.GetComponent<HeadTrackingAR> ().enabled = true; //Enabling the headset gyroscope.
		}

		}
	}

	void FixedUpdate()
	{
		earthObj.transform.Rotate (new Vector3 (0,30,0) * Time.deltaTime *speed);//a linear rotation for the earth on it's own axis
	}
}
