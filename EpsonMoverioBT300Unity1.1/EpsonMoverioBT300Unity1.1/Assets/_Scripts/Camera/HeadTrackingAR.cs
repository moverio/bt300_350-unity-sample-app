/*The headtracking class shows how to use headtracking on Moverio
 *Keep in mind that no special actions with the Moverio SDK or plugin
 *were done here. It all uses the standard Unity Android feature set. 
 */ 

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("Moverio/HeadTrackingAR")]

public class HeadTrackingAR : MonoBehaviour
{

	private static HeadTrackingAR _instance;
	public static HeadTrackingAR Instance
	{
		get
		{
			return _instance;
		}
	}

	bool _gyroIsAvailable;
	Gyroscope _head;
	Quaternion _callibration;
	Transform _t;
	GameObject HeadTracker;
	public Text txt;
	float yO = 0.0f;

	void Awake()
	{
		_instance = this;
	}


	
	void Start()
	{
		_t = transform;

		yO = _t.position.y;

		HeadTracker = new GameObject("HeadTracker");
		HeadTracker.transform.position = transform.position;
		transform.parent = HeadTracker.transform;
		_gyroIsAvailable = Input.isGyroAvailable;

		
		if (_gyroIsAvailable) 
		{		
			//_head = Input.gyro;
			Input.gyro.enabled = true;
			//Input.gyro.updateInterval = 1f/60f;
			//_head.updateInterval = 1f/60f;
		}
		HeadTracker.transform.eulerAngles = new Vector3(90,180,0);
		_callibration = Quaternion.Euler(new Vector3(0,0,180));
	}

	
	void Update()
	{			
		
		

		
		if (_gyroIsAvailable) 
		{
			//_t.localRotation = Quaternion.Slerp(transform.localRotation, Input.gyro.attitude * _callibration, Time.deltaTime*30);
			transform.Rotate(-Input.gyro.rotationRateUnbiased.x,-Input.gyro.rotationRateUnbiased.y,Mathf.Clamp(-Input.gyro.rotationRateUnbiased.z,-0.2f,.2f));
			txt.text =  "GYRO Headset : "+Input.gyro.rotationRateUnbiased;
		}


	}
}