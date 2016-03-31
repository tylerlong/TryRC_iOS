using System;

using UIKit;
using Foundation;

namespace TryRC_iOS
{
	public partial class ViewController : UIViewController
	{
		private RingCentral.Platform platform;

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

			// send sms
			if (platform == null) {
				platform = new RingCentral.SDK (appKeyTextField.Text, appSecretTextField.Text,
					serverPickerView.SelectedRowInComponent(0) == 0 ? "https://platform.devtest.ringcentral.com" : "https://platform.ringcentral.com"
				).GetPlatform ();
			}
			if (!platform.LoggedIn ()) {
				var tokens = usernameTextField.Text.Split ('-');
				var username = tokens [0];
				var extension = tokens.Length > 1 ? tokens [1] : null;
				platform.Authorize (username, extension, passwordTextField.Text, true);
			}
			var request = new RingCentral.Http.Request ("/account/~/extension/~/sms",
				string.Format ("{{ \"text\": \"{0}\", \"from\": {{ \"phoneNumber\": \"{1}\" }}, \"to\": [{{ \"phoneNumber\": \"{2}\" }}]}}",
					messageTextField.Text, usernameTextField.Text, sendToTextField.Text));
			var response = platform.Post (request);
			Console.WriteLine("Sms sent, status code is: " + response.GetStatus ());
//			var alert = new NSAlert ();
//			alert.MessageText = "Sms sent, status code is: " + response.GetStatus ();
//			alert.RunModal ();
		}
	}
}
