﻿using System;

using UIKit;
using Foundation;

namespace TryRC_iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			serverPickerView.Model = new ServerPickerViewModel ();
			appKeyTextField.Text = NSUserDefaults.StandardUserDefaults.StringForKey ("appKey") ?? "";
			appSecretTextField.Text = NSUserDefaults.StandardUserDefaults.StringForKey ("appSecret") ?? "";
			serverPickerView.Select (NSUserDefaults.StandardUserDefaults.IntForKey ("server"), 0, false);
			usernameTextField.Text = NSUserDefaults.StandardUserDefaults.StringForKey ("username") ?? "";
			passwordTextField.Text = NSUserDefaults.StandardUserDefaults.StringForKey ("password") ?? "";
			sendToTextField.Text = NSUserDefaults.StandardUserDefaults.StringForKey ("sendTo") ?? "";
			messageTextField.Text = NSUserDefaults.StandardUserDefaults.StringForKey ("message") ?? "";
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public class ServerPickerViewModel : UIPickerViewModel
		{
			public override nint GetComponentCount (UIPickerView pickerView)
			{
				return 1;
			}

			public override nint GetRowsInComponent (UIPickerView pickerView, nint component)
			{
				return 2;
			}

			public override string GetTitle (UIPickerView pickerView, nint row, nint component)
			{
				return (new string[2]{"Sandbox", "Production"})[row];
			}
		}

		partial void SendSMS (Foundation.NSObject sender)
		{
			// save user input
			NSUserDefaults.StandardUserDefaults.SetString (appKeyTextField.Text, "appKey");
			NSUserDefaults.StandardUserDefaults.SetString (appSecretTextField.Text, "appSecret");
			NSUserDefaults.StandardUserDefaults.SetInt(serverPickerView.SelectedRowInComponent(0), "server");
			NSUserDefaults.StandardUserDefaults.SetString (usernameTextField.Text, "username");
			NSUserDefaults.StandardUserDefaults.SetString (passwordTextField.Text, "password");
			NSUserDefaults.StandardUserDefaults.SetString (sendToTextField.Text, "sendTo");
			NSUserDefaults.StandardUserDefaults.SetString (messageTextField.Text, "message");
		}
	}
}
