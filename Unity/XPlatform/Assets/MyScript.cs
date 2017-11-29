using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class MyScript : MonoBehaviour {
	//https://docs.unity3d.com/Manual/PlatformDependentCompilation.html
	#if UNITY_IOS
	[DllImport ("__Internal")]
	private static extern int sum(int op1,int op2);
	#elif UNITY_ANDROID
	//android name of the Dll is "name of my .so file".replace("lib","").replace(".so",""), here my file is named : 'libnative.so'
	[DllImport ("native")]
	private static extern int sum(int op1,int op2);
	#else
	//fallback function
	private int sum(int op1,int op2){
		return op1 + op2;
	}
	#endif

	private int op1Val = 0;

	private int op2Val = 0;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
		var inputs = gameObject.GetComponentsInChildren<InputField>();
		foreach (InputField i in inputs){

			Debug.Log (i.ToString ());
			if(i.name.Equals("op1")){
				i.onValueChanged.AddListener (SubmitOp1);
			}
			else if(i.name.Equals("op2")){
				i.onValueChanged.AddListener (SubmitOp2);
			}

		}
	}

	/// <summary>
	/// Called every time op1 value change
	/// </summary>
	/// <param name="arg0">Arg0.</param>
	private void SubmitOp1(string arg0)
	{
		Debug.Log(arg0);
		try{
			int val = int.Parse(arg0);
			this.op1Val= val;
			this.performOp(this.op1Val,this.op2Val);
		}
		catch(Exception e){
			Debug.Log(e);
			this.op1Val = 0;
			this.displayError (e);
		}
	}

	/// <summary>
	/// Called every time op2 value change
	/// </summary>
	/// <param name="arg0">Arg0.</param>
	private void SubmitOp2(string arg0)
	{
		Debug.Log(arg0);
		try{
			int val = int.Parse(arg0);
			this.op2Val=val;
			this.performOp(this.op1Val,this.op2Val);
		}
		catch(Exception e){
			Debug.Log(e);
			this.op2Val = 0;
			this.displayError (e);
		}
	}
		
	/// <summary>
	/// Perform an operation and display results in UI
	/// </summary>
	/// <param name="a">Operand value A</param>
	/// <param name="b">Operand value B</param>
	private void performOp(int a,int b){
		Debug.Log (a);
		Debug.Log (b);
		var res = gameObject.GetComponentsInChildren<Text>();
		foreach (Text t in res) {
			if (t.name.Equals ("output")) {

				String platForm = "Non mobile";
				#if UNITY_IOS
				//if (Application.platform == RuntimePlatform.IPhonePlayer)
				platForm="iOS";
				#elif UNITY_ANDROID
				platForm="Android";
				#else
				//Do nothing
				#endif
				t.text = platForm + " : " + sum(a,b).ToString ();

				break;
			}
		}
	}


	/// <summary>
	/// Display an error message according to an exception
	/// </summary>
	/// <param name="e">E.</param>
	private void displayError(Exception e){
		var res = gameObject.GetComponentsInChildren<Text>();
		foreach (Text t in res) {
			if (t.name.Equals ("output")) {
				t.text = "An error occured : "+e.Message+" "+e.StackTrace;	
				break;
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
