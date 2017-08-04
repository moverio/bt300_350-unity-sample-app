/*############################################################################################################################################################
#                                                                                   																		 #
# File:   ControllerTargetmove.cs                                                                                                                            #
# Version: Release 01.00                                                                                                                                     # 	
# Date :   June 2017                                                                                                                                         # 	
#                                                                                                                                                            # 		
#                                                                                    																		 #
# Purpose:  To demonstrate the handheld controller's input: Trackpad and Enterkey.											  						     	 #
#			The scene has one capsule as a player which moves on the basis of touch input from trackpad.                                                     #
#            Player changes color by hitting Enterkey.            				                                                                             #
#                                                                                                                                                            #
#																																							 #
# Note: 	This script has been designed for Moverio for Andriod, release 5.1 & above.																	     #
#       	Do not attempt to run this script in earlier versions of Andriod.      																	         #
#                                                                                    																		 #
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                     																		     #
#                                                                                    																		 #
############################################################################################################################################################*/

using UnityEngine;          // Using : imports the namespaces which are the collection of classes and other data types that are used to categorize the Library;
using System.Collections;

public class controllerTargetmove : MonoBehaviour   //Class name : controllerTargetmove
{
	
	#region DeclaredVariables
	[SerializeField]
	float speed =0.8f;

	[SerializeField]
	Material mat;

	private float  _colorCount=0; 
	private Vector3 newPosition;
	private bool _move;
	private float _currentLerpTime;
	private float _PercentageOfChange = 0f;//percentage of change 
	private Color newCol;

	#endregion   //declare all the variables under this region.

	void Start () {
		newPosition = transform.position;  // Storing the current position. 
		_move = false;                    // Movement is set to false at current.

	}
	void Update()
	{
		
		if (Input.GetMouseButtonDown(0) && _move == false)// Capturing the touch input from trackpad.
		{
			RaycastHit hit;                               // Casting an invisible ray to point the location.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{  
				newPosition = hit.point;                     //Capturing the ray position after pressing onto touchpad.
				_move = true;                                // Movement is set to true.

			}
		}

		if (_move == true )
		{
			_PercentageOfChange = _PercentageOfChange + (Time.deltaTime * speed); //Storing and increasing ChangeMovement.
			_PercentageOfChange = Mathf.Sin(_PercentageOfChange * Mathf.PI * 0.5f); //Increased-changeMovement applied to get an angle for movement.
			transform.position =Vector3.Lerp(transform.position,new Vector3( newPosition.x,transform.position.y,newPosition.z),_PercentageOfChange); // Applying Linear Interpolation for Smooth Movement on touch input.

			if (transform.position == new Vector3 (newPosition.x, transform.position.y, newPosition.z))  //Checking the idle position of the corrent trasnform of player-Object.
			{
				_move = false;
				_PercentageOfChange = 0;                                      
			}
		}

		if (Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Space))  //Getting input from EnterKey.
		{
			 	_colorCount++;//Applying Random colour's material.
			if (_colorCount % 3 == 0) 
			{
				newCol = Color.red;
			} 
			else if (_colorCount % 2 == 0) 
			{
				newCol = Color.green;
			} 
			else
				newCol = Color.yellow;

		mat.color = newCol;				
		}

	}


}
