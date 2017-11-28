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
	[DllImport ("native")]
	private static extern int sum(int op1,int op2);
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

	private void SubmitOp1(string arg0)
	{
		Debug.Log(arg0);
		try{
			int val = int.Parse(arg0);
			this.op1Val= val;
			this.treatRes(this.op1Val,this.op2Val);
		}
		catch(Exception e){
			Debug.Log(e);
			this.op1Val = 0;
			this.displayError (e);
		}
	}

	private void SubmitOp2(string arg0)
	{
		Debug.Log(arg0);
		try{
			int val = int.Parse(arg0);
			this.op2Val=val;
			this.treatRes(this.op1Val,this.op2Val);
		}
		catch(Exception e){
			Debug.Log(e);
			this.op2Val = 0;
			this.displayError (e);
		}
	}
		
	private void treatRes(int a,int b){
		Debug.Log (a);
		Debug.Log (b);
		var res = gameObject.GetComponentsInChildren<Text>();
		foreach (Text t in res) {
			if (t.name.Equals ("output")) {

				#if UNITY_IOS
				if (Application.platform == RuntimePlatform.IPhonePlayer)
				{
					t.text = "iOS : "+sum(a,b).ToString();
				}
				else{
					t.text ="KO";
				}
				#elif UNITY_ANDROID
				t.text = "Android : "+sum(a,b).ToString();
				#else
				t.text = "Non mobile : "+(a+b).ToString();
				#endif


				break;
			}
		}
	}



	private void displayError(Exception e){
		var res = gameObject.GetComponentsInChildren<Text>();
		foreach (Text t in res) {
			if (t.name.Equals ("output")) {
				t.text = "One of the two operand as an incorrect value : "+e.Message+" "+e.StackTrace;	
				break;
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
