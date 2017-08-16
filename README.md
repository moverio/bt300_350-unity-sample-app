################################################
#			  	               #								
#    BT-300 / BT-350 Sample Unity App Readme   #							
#                                              #							
################################################														

---------------------------------------
Introduction
---------------------------------------
This is a sample application built using the following plugin for the BT-300 / BT-350: 
	https://github.com/moverio/BT300-Unity_Plugin-Preview

This will show how to read data from various sensors for use in a Unity Project. 




This Application Demonstrates the Following Features:

-----------------------------------
 1. Accelerometer Module          
-----------------------------------
   
The working of this module demonstrates Headset and controller movement.
A ball moves on the basis of Device's accelerometer values.
          		
-------------------------------------
2. Gyroscope & Magnetic-Field Module
-------------------------------------

This module is to demonstrate see-through capability of the glass as well as the Gyroscopic value. 
Magnetometer will locate the real North on the basis of controller's Magnetic field raw data.

------------------------------------------
4. Controller & Illumination Sensor Module 
------------------------------------------

This module shows demonstrate device's handheld controller and illumination sensor mentioned below.
	(a)   Enterkey: Changes capsule color.
	(b)   Crosskey: Adjusts the plane according to eyesight.
	(c)   Trackpad: Moves the capsule on the basis of touch input.
	(d)   Brightness Bar: Changes the intensity of screen brightness.

-------------------------------
5. Actual Sensor Module
-------------------------------

This module is the combination of Accelerometer and Gyroscopic values.
Two planes with Green and Red ball can be observed.
One ball at a time can move, if it is visible to eyesight.

-------------------------------
6. Rotational Vector Module
-------------------------------

This module is based on the handheld device's rotation values.
A cube is placed to show the rotation in all axis.

-------------------------------
7. Headset Tap Feature
-------------------------------

While in a scene described above, the user can tap the headset to change to the next scene. 

------------------------------------------------------
Application Requirements and Installation
------------------------------------------------------

Requirements: EPSON Moverio BT-300 or BT-350 Smart Glasses, Unity Editor 5.X or above.

How to import the project into Unity Editor:

	Step 1 > Get a Unity License from https://store.unity.com/ and install locally.
	Step 2 > Clone this repo to your local machine.
	Step 3 > Go to File->Open and navigate to the “EpsonMoverioBT300Unity1.1” folder.
	Step 4 > Click “Open” and the project will be imported into Unity. 		  
                  
How to install application onto the device:

	Step 1 > Copy the .apk (Andriod Package Kit) file into the device's memory.
	Step 2 > Locate the .apk using file explorer.
	Step 3 > Click on file and install it.
	Step 4 > Run the application.
		  
Configuration: The BT-300 runs Android 5.1 or API Level 22.

See Also: 
	BT-300 Unity Plugin: https://github.com/moverio/BT300-Unity_Plugin-Preview
	BT-300 SDK: https://tech.moverio.epson.com/en/bt-300/sdk_download.html
	BT-300 Documentation: https://tech.moverio.epson.com/en/bt-300/document.html
	BT-350 Documentation: https://tech.moverio.epson.com/en/bt-350/document.html
	Get Unity: https://store.unity.com/


