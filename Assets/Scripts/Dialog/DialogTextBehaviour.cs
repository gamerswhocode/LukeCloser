using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using AssemblyCSharp;

public class DialogTextBehaviour : DialogListener, IDialogObject{

	public List<String> dialogs;
	public String currentDialog;
	public bool isDialogStarted = false;
	public bool isTouchEnabled = false;
	public bool isTextChanging = false;
	public bool isTextFadedOut = false;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if(isDialogStarted)
		{
			if (isTouchEnabled && Input.GetMouseButtonUp (0)) 
			{
				isTextChanging = true;
				isTouchEnabled = false;
			}
			if(isTextChanging)
			{
				ChangeText();
			}
		}
	}

	void ChangeText()
	{
		if(!isTextFadedOut&&TextFadeOut())
		{
			try
			{
				currentDialog = dialogs[dialogs.IndexOf(currentDialog)+1];
			}
			catch(ArgumentOutOfRangeException e)
			{
				currentDialog = "";
				DialogMaster.Instance.EndDialog(this, dialogs);
			}	
			GetComponent<TextMesh> ().text = currentDialog;
			isTextFadedOut = true;
			
		}

		if(isTextFadedOut&&TextFadeIn())
		{
			isTextFadedOut = false;
			isTextChanging = false;
			isTouchEnabled = true;
		}
	}

	bool TextFadeIn()
	{
		if (GetComponent<TextMesh>().color.a < 1f) 
		{
			GetComponent<TextMesh>().color += new Color(0f,0f,0f,0.05f);
			return false;
		}
		else
		{
			GetComponent<TextMesh>().color = new Color(1f,1f,1f,1f);
			return true;
		}
	}

	bool TextFadeOut()
	{
		if (GetComponent<TextMesh>().color.a > 0f) 
		{
			GetComponent<TextMesh>().color -= new Color(0f,0f,0f,0.05f);
			return false;
		}
		else
		{
			GetComponent<TextMesh>().color = new Color(1f,1f,1f,0f);
			return true;
		}
	}

	#region IDialogObject implementation
	public void DialogStarted (List<string> dialogs)
	{	
		this.dialogs = dialogs;
		this.currentDialog = dialogs [0];
		GetComponent<TextMesh> ().text = currentDialog;
		this.isDialogStarted = true;
		isTouchEnabled = true;
	}
	public void DialogEnded ()
	{
		isTouchEnabled = false;
		isDialogStarted = false;
	}
	#endregion
}
