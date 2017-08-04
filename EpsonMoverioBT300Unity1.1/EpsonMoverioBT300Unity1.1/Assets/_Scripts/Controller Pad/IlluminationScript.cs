/*#############################################################################################
#                                                                                      		  #
# File:    illuminationScript.cs                                                      		  #
# Version: Release 01.00                                                               		  #
# Date :   June 2017                                                             	   		  #
#                                                                               	   		  #
#                                                                                      		  #
# Purpose – To demonstrate the illumination sensor inputs by adjusting the screen brightness. #
# 																						      #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above.		  #
#           Do not attempt to run this script in earlier versions of Andriod.         		  #
#                                                                                      		  #
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                         		  #
#                                                                                      		  #
#############################################################################################*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IlluminationScript : MonoBehaviour 
{

	// Use this for initialization
	[SerializeField]
	int BrightnessValues;

	[SerializeField]
	Slider brightAdjust; 
		
	void Update () 
	{
		//Adjusting the intensity of the screen using brightnessvalues.
		BrightnessValues = (int)brightAdjust.value;
		MoverioController.Instance.SetDisplayBrightness(BrightnessValues); //Setting the brightness value.
	}



}
