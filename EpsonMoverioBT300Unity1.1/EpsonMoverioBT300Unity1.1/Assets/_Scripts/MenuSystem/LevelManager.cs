/*###########################################################################################
#                                                                                      		#
# File:    LevelManager.cs                                              	        		#
# Version: Release 01.00                                                               		#
# Date :   June 2017                                                             	   		#
# 				                                                                	   		#
#                                                                                      		#
# Purpose – Switching between scenes using UserInterface.                                   #
#                                                                                           #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.		#
#           Do not attempt to run this script in earlier versions of Andriod.      		    #
#                                                                                      		#
# Copyright 2017 Seiko Epson Corporation. All rights reserved.    		             		#
#                                                                                      		#
###########################################################################################*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

	public void LoadLevel(string name) //Public Method to change the scene with respect to scene name.
	{
		//Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);

	}

	public void QuitRequest() //Public method to quit the application.
	{
		//Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
