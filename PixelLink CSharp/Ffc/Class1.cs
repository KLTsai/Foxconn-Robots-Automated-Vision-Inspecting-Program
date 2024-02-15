//
//
// An application that demonstrates how to disable or enable flat-field correction (FFC) on a camera. 
//
// This is not something you'd normally want to do with a camera, but a few clients
// have asked how to do this, and it's not part of the PixeLINK API assembly. 
//
// This application assumes there's only one camera connected to the host.
//
// NOTE: FFC defaults to ON when a camera boots.
//



using System;
using PixeLINK;



namespace ffc
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Init
			int hCamera = 0;
			ReturnCode rc = Api.Initialize(0, ref hCamera);
			if (!Api.IsSuccess(rc)) 
			{
				Console.WriteLine("Failed to initialize a camera ("+  rc.ToString() + ")");
				return;
			}

			// Disable FFC
			rc = FFCControl.Enable(hCamera, false);
			if (Api.IsSuccess(rc)) 
			{
				Console.WriteLine("FFC successfully disabled");
				
			} 
			else 
			{
				Console.WriteLine("Failed to disable FFC ("+  rc.ToString() + ")");
			}

			// Use Capture OEM's LUT and FFC tab to confirm that FFC is disabled

			Api.Uninitialize(hCamera);
		}
	}
}
