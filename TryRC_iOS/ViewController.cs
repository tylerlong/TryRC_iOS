using System;

using UIKit;

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
	}
}

