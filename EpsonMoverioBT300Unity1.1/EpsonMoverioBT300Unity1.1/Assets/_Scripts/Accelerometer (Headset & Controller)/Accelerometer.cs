/*##################################################################################################
#                                                                                     		       #
# File:    Acclerometer.cs                                                    		   		       #
# Version: Release 01.00                                                               		       #
# Date :   June 2017                                                             	   		       #
#                                                                 	   		                       #
#                                                                                     		       #
# Purpose – To demonstrate the Accelerometer inputs from the device through the ball movement.     #
# 																							       #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.		       #
#           Do not attempt to run this script in earlier versions of Andriod.         		       #
#                                                                                      		       #
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                        		       #
#                                                                                     		       #
###################################################################################################*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Headset and Controller Accelerometer Script
public class Accelerometer : MonoBehaviour 
{

	#region DeclaredVariables
	[SerializeField] //SerializeField to show modify private variables from editor as well.
	Text  values;

	[SerializeField]
	GameObject sphere;

	[SerializeField]
	float speed; // Accelaration of the ball.

	[SerializeField]
	public float threshold=2;

	int TYPE_HEADSET_ACCELEROMETER = 0 , TYPE_CONTROLLER_ACCELEROMETER = 1;
	private Rigidbody _sphereRigidboby; // Declaration of selected Physics Component.
	private Vector3 _ballMovement = Vector3.zero; // Temporary variable to store the movement of the ball.
	private bool _tglBtn;
	private Vector3 _currentValues = Vector3.zero;
	private LinkedList<Vector3> _positions = new LinkedList<Vector3>();
	private Vector3 _temp = new Vector3 ();

	#endregion 



	void Start () 
	{
		_sphereRigidboby = sphere.GetComponent<Rigidbody>(); // Initializing the Rigidbody component.
		_positions.AddLast(Vector3.zero);	    
	}



	void Update() 
	{
		if (MoverioController.Instance.MoverioDevice == true) 
		{
			_currentValues = new Vector3 (-MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ACCELEROMETER) [0], 0.0f, MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ACCELEROMETER) [2]);//Switching controls from headset to controller
			_temp = _positions.First.Value; // Capturing the LastFrame's position Value.

			if ((_currentValues - _temp).magnitude > threshold)  
			{ 

				_tglBtn = true;
			}
			else 
			{			
				_tglBtn = false;
			}

		}
	}          
	// Update is called once per frame

	void FixedUpdate () 
	{
		if(MoverioController.Instance.MoverioDevice == true)
		{
			if (_tglBtn == false ) //correction 
			{
				_ballMovement = new Vector3 (-MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [0], 0.0f, MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [2]);  //Accessing the values of the accelerometer form headset.
				values.text = "HEADSET ACCEL x: " + Mathf.Round(MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [0]).ToString () + ", " +
				"y: " + Mathf.Round(MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [1]).ToString () + ", " +
				"z: " + Mathf.Round(MoverioController.Instance.GetSensorData (TYPE_HEADSET_ACCELEROMETER) [2]).ToString ();

			}

		else 
			{
				_ballMovement = new Vector3 (-MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ACCELEROMETER) [0], 0.0f, MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ACCELEROMETER) [2]);  //Accessing the values of the accelerometer from controller. 
				values.text = "CONTROLLER ACCEL x: " + Mathf.Round(MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ACCELEROMETER) [0]).ToString () + ", " +
				"y: " + Mathf.Round(MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ACCELEROMETER) [1]).ToString () + ", " +
				"z: " + Mathf.Round(MoverioController.Instance.GetSensorData (TYPE_CONTROLLER_ACCELEROMETER) [2]).ToString ();

			}

		_sphereRigidboby.AddForce (_ballMovement * speed * Time.deltaTime);  // Adding Force to the ball with respect to the Accelerometer values and Speed.
		}
	}


	void LateUpdate()
	{
		_positions.AddLast(_currentValues);
		if (_positions.Count > 60) 
		{
			_positions.RemoveFirst ();
		}
	}


}
