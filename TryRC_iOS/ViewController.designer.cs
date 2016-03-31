// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TryRC_iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITextField appKeyTextField { get; set; }

		[Outlet]
		UIKit.UITextField appSecretTextField { get; set; }

		[Outlet]
		UIKit.UITextField messageTextField { get; set; }

		[Outlet]
		UIKit.UITextField passwordTextField { get; set; }

		[Outlet]
		UIKit.UITextField sendToTextField { get; set; }

		[Outlet]
		UIKit.UIPickerView serverPickerView { get; set; }

		[Outlet]
		UIKit.UITextField usernameTextField { get; set; }

		[Action ("SendSMS:")]
		partial void SendSMS (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (appKeyTextField != null) {
				appKeyTextField.Dispose ();
				appKeyTextField = null;
			}

			if (appSecretTextField != null) {
				appSecretTextField.Dispose ();
				appSecretTextField = null;
			}

			if (serverPickerView != null) {
				serverPickerView.Dispose ();
				serverPickerView = null;
			}

			if (usernameTextField != null) {
				usernameTextField.Dispose ();
				usernameTextField = null;
			}

			if (passwordTextField != null) {
				passwordTextField.Dispose ();
				passwordTextField = null;
			}

			if (sendToTextField != null) {
				sendToTextField.Dispose ();
				sendToTextField = null;
			}

			if (messageTextField != null) {
				messageTextField.Dispose ();
				messageTextField = null;
			}
		}
	}
}
