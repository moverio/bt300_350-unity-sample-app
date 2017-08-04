/*The Moverio controller allows developers to actually
 *use the various functions and sensors defined in the Moverio
 *SDK. It also ensures that the project runs on a Moverio device. 
 *Essentially the MoverioController calls to the bridge program defined
 *in java which will then activate the necessary functionality. 
 */

using UnityEngine;
using System.Collections;


//define Various Parameters for the 
//Moverio Display types

public enum MoverioEventType
{
	Display3DOn,
	Display3DOff,
	DisplayBrightnessChange,

	MuteDisplayOn,
	MuteDisplayOff,

}

//Set Parameters to remember if the display
//is in 2D or 3D mode. 

public enum MoverioDisplayType
{
	Display3D,
	Display2D
}


[AddComponentMenu("Moverio/MoverioController")]

public class MoverioController : MonoBehaviour {
	
	public delegate void MoverioEvent(MoverioEventType type);
	public static event MoverioEvent OnMoverioStateChange;

	//Define default parameters for the Moverio. 

	public int InitialScreenBrightness = 20;

	public MoverioDisplayType InitialDisplayMode = MoverioDisplayType.Display2D;
	

	private AndroidJavaClass _unityPlayer;
	private AndroidJavaObject _currentActivity;

	private static MoverioController _instance;

	//Reminds developers to place the Moverio Prefabs into
	//their scene. 
	public static MoverioController Instance
	{
		get
		{
			if(_instance == null)
			{
				Debug.Log("Please Add MoverioController Prefab To Scene!");
			}
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
	}

	public bool MoverioDevice = true;

	void Start () 
	{

		CheckDeviceType();

		SetJavaClass();

		SetDefaultSettings();

	}

	//Function to make sure the device is a Moverio BT-300. 
	void CheckDeviceType()
	{
		if(SystemInfo.deviceModel.Equals("EPSON EMBT3C"))
		{

			AndroidJNI.AttachCurrentThread();

		}
		else
		{

			MoverioDevice = false;

		}
	}

	//Sets Display to full brightness and 2D mode by default. 
	void SetDefaultSettings()
	{
		if(InitialDisplayMode.Equals(MoverioDisplayType.Display3D))
		{
			SetDisplay3D(true);
		}
		else 
		{
			SetDisplay3D(false);
		}

		if(!InitialScreenBrightness.Equals(20))
		{
			string msg = "";
			msg = SetDisplayBrightness(InitialScreenBrightness);

			Debug.Log(msg);
		}

	}

	void SetJavaClass()
	{
#if UNITY_ANDROID && !UNITY_EDITOR

		if(MoverioDevice)
		{
			using(_unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				_currentActivity = _unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
			}

			_currentActivity.Call("SetMoverioDevice");
		}

#endif
	}

	//function that enables developers to recieve sensor data from the Moverio. 

	public float[] GetSensorData(int sensorType)
	{
		float[] value = null;
		
		#if UNITY_ANDROID && !UNITY_EDITOR
		
		if(MoverioDevice)
		{
			value = _currentActivity.Call<float[]> ("GetSensorData", sensorType);
		}
		
		#endif
		return value;
	}

	//Recognizes a headset tap. 
	public bool GetHeadsetTap()
	{
		bool value = false;
		
		#if UNITY_ANDROID && !UNITY_EDITOR
		
		if(MoverioDevice)
		{
			value = _currentActivity.Call<bool> ("GetHeadsetTap");
		}
		
		#endif
		return value;
	}

	//function to keep count of how many headset taps have occurred. 
	public int GetHeadsetTapCount()
	{
		int value = 0;
		
		#if UNITY_ANDROID && !UNITY_EDITOR
		
		if(MoverioDevice)
		{
			value = _currentActivity.Call<int> ("GetHeadsetTapCount");
		}
		
		#endif
		return value;
	}
		


	/*
	 * 
	 * SetDisplayBrightness takes an int between 0 - 20 
	 * will automatically return an ERROR msg for out of range
	 * 
	 */


	public string SetDisplayBrightness(int brightness)
	{
		string msg = "NOT SET";

#if UNITY_ANDROID && !UNITY_EDITOR

		if(MoverioDevice)
		{
			msg = _currentActivity.Call<string> ("SetDisplayBrightness", brightness);
		}

#endif

		if(OnMoverioStateChange != null)
		{
			OnMoverioStateChange(MoverioEventType.DisplayBrightnessChange);
		}

		return msg;
	}

	/*
	 * 
	 * Gets Current Display Brightness level (an int between 0 - 20)
	 * 
	 */

	public int GetDisplayBrightness()
	{
		int i = -1;

#if UNITY_ANDROID && !UNITY_EDITOR

		if(MoverioDevice)
		{
			i = _currentActivity.Call<int>("GetDisplayBrightness");
		}

#endif

		return i;
	}

	/*
	 * 
	 * Sets 3D Display toggle on/off
	 * 
	 */

	public void SetDisplay3D(bool on)
	{
#if UNITY_ANDROID && !UNITY_EDITOR

		if(MoverioDevice)
		{
			_currentActivity.Call("SetDisplay3D", on);
		}

#endif

		if(OnMoverioStateChange != null)
		{
			MoverioEventType eType;

			if(on)
			{
				eType = MoverioEventType.Display3DOn;
			} else {
				eType = MoverioEventType.Display3DOff;
			}

			OnMoverioStateChange(eType);
		}
	}




	/*
	 * 
	 * Sets Mute Display toggle on/off
	 * 
	 */

	public void MuteDisplay(bool mute)
	{

#if UNITY_ANDROID && !UNITY_EDITOR

		if(MoverioDevice)
		{
			_currentActivity.Call ("MuteDisplay", mute);
		}

#endif

		if(OnMoverioStateChange != null)
		{
			MoverioEventType eType;
			
			if(mute)
			{
				eType = MoverioEventType.MuteDisplayOn;
			} else {
				eType = MoverioEventType.MuteDisplayOff;
			}
			
			OnMoverioStateChange(eType);
		}


	}


}
