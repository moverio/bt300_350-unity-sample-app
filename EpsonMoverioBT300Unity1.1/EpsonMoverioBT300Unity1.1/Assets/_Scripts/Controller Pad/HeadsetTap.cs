/*#######################################################################################
#                                                                                       #
# File:    HeadSetTap.cs                                                         	    #
# Version: Release 01.00                                                                #
# Date :   June 2017                                                             	    #
#                                                                                	    #
#                                                                                       #
# Purpose – To demonstrate Headset-tap inputs through navigation of scenes.             #
#                                                                                       #
# Note:     This script has been designed for Moverio for Andriod, release 5.1 & above. #
#           Do not attempt to run this script in earlier versions of Andriod.  	        #
#                                                                                       #
# Copyright 2017 Seiko Epson Corporation. All rights reserved.                          #
#                                                                                       #
#######################################################################################*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HeadsetTap : MonoBehaviour 
{

	// Use this for initialization

	private Scene _sceneName;
	private bool _changeCounter;
	private int _index;

	void Start () 
	{
		_sceneName = SceneManager.GetActiveScene ();    
		_changeCounter = false;
		_index = 0;		
	}
	
	// Update is called once per frame
	void Update () 

	{   //detection of headset tap and navigation of the scene in ascending order
		_changeCounter = MoverioController.Instance.GetHeadsetTap ();
		_index = _sceneName.buildIndex;
		while(MoverioController.Instance.GetHeadsetTap () != false)  //Detecting headset tap count.
		{

			if (_changeCounter == true)  
			{
			
				_changeCounter = false;
				if (_sceneName.buildIndex != SceneManager.sceneCountInBuildSettings || _sceneName.buildIndex != 0) 
				{
					_index++;
					SceneManager.LoadScene (_index); //Navigating to different Scene
				}
					
			}
		}
	}
}
