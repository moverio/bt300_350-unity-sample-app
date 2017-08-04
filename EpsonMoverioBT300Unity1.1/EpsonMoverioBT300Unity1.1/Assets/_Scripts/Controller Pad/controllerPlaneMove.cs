/*###########################################################################################
#                                                                                      		#
# File:    controllerPlaneMove.cs                                                      		#
# Version: Release 01.00                                                               		#
# Date :   June 2017                                                             	   		#
#                                                                               	   		#
#                                                                                      		#
# Purpose – To demonstrate crosskey inputs to move the plane in different directions.       #
#                                                                                           #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.		#
#           Do not attempt to run this script in earlier versions of Andriod.      		    #
#                                                                                      		#
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                      		#
#                                                                                      		#
###########################################################################################*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controllerPlaneMove : MonoBehaviour 

{
	private float x=0f , y=0f;


	void Update() 
	{
		
		MovePlane ();
	}



	void MovePlane()  //Movement of the plane according to the controller input
	{
		
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			y++;
		}
		else if (Input.GetKey (KeyCode.DownArrow)) 
		{
			y--;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			x--;
		}
		else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			x++;
		}

		transform.position = new Vector3 (x, y, transform.position.z);
	}


}

