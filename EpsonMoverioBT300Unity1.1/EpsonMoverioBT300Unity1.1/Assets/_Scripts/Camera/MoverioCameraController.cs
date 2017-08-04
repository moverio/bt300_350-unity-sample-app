/*The Moverio Camera Controller simply takes care
 *allows developers to properly use the Moverio Display. 
 * Essentially it takes proper mind of both displays
 * and eyes in order to properly account for 2D and 3D. 
 * 
 */


using UnityEngine;
using System.Collections;

[AddComponentMenu("Moverio/MoverioCameraController")]

public class MoverioCameraController : MonoBehaviour {

	private static MoverioCameraController _instance;

	//Makes sure the Prefab is added to the scene. 
	public static MoverioCameraController Instance
	{
		get
		{
			if(_instance == null)
			{
				Debug.Log("Please Add MoverioCameraRig Prefab To Scene!");
			}

			return _instance;
		}
	}

	//Variables to take care of the various cameras. 
	public Camera LeftEyeCam, RightEyeCam, Cam2D;

	public float PupillaryDistance = 0.05f;

	MoverioDisplayType _displayState;

	void Awake()
	{
		_instance = this;
	}

	//starts cameras to enable a full screen 2D view. 
	void Start()
	{
		LeftEyeCam.aspect = RightEyeCam.aspect = Screen.width / Screen.height * 2.0f;
		SetPupillaryDistance(PupillaryDistance);
	}


	//sets parameters to adjust the cameras when moving from 2D to 3D. 
	public void SetPupillaryDistance(float pDist)
	{
		PupillaryDistance = pDist;

		LeftEyeCam.transform.localPosition = new Vector3(-PupillaryDistance, 0.0f, 0.0f);
		RightEyeCam.transform.localPosition = new Vector3(PupillaryDistance, 0.0f, 0.0f);
	}
		
	void OnEnable()
	{
		MoverioController.OnMoverioStateChange += HandleOnMoverioStateChange;
	}

	void OnDisable()
	{
		MoverioController.OnMoverioStateChange -= HandleOnMoverioStateChange;
	}

	//Function to handle switching from 2D to 3D. 
	void HandleOnMoverioStateChange (MoverioEventType type)
	{
		switch(type)
		{
		case MoverioEventType.Display3DOff:
			SetCurrentDisplayType(MoverioDisplayType.Display2D);
			break;
		case MoverioEventType.Display3DOn:
			SetCurrentDisplayType(MoverioDisplayType.Display3D);
			break;
		}

	}

	//Reads current display mode. 
	public MoverioDisplayType GetCurrentDisplayState()
	{
		return _displayState;
	}

	//creates switches between a signle camera mode and double camera mode
	//for 2D and 3D switching. 
	public void SetCurrentDisplayType(MoverioDisplayType type)
	{
		_displayState = type;

		switch(_displayState)
		{
		case MoverioDisplayType.Display2D:
			LeftEyeCam.enabled = RightEyeCam.enabled = false;
			Cam2D.enabled = true;
			break;
		case MoverioDisplayType.Display3D:
			LeftEyeCam.enabled = RightEyeCam.enabled = true;
			Cam2D.enabled = false;
			break;
		}
	}


}
