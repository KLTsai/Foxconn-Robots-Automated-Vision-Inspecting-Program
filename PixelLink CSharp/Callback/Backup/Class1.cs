// 
// Class1.cs
//
// In this program we demonstrate two ways to interact with the data pointed to in a callback function:
// OPTION_1 uses 'unsafe' code to read data from the PixeLINK API frame buffer
// OPTION_2 uses Marshal.ReadByte to read data from the PixeLINK API frame buffer
//
// To keep things simple, we configure the camera for 8-bit data
// i.e. MONO8 for mono cameras, BAYER8 for colour cameras.
//
#define OPTION_2


using System;
using System.Threading;
using PixeLINK;


namespace Callback
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
			Class1 c1 = new Class1();
			c1.RunDemo();
		}

		private PixelFormat GetPixelFormat(int hCamera)
		{
			FeatureFlags flags = 0;
			int numParms = 1;
			float[] parms = new float[numParms];
			Api.GetFeature(hCamera, Feature.PixelFormat,  ref flags, ref numParms, parms);
			return (PixelFormat)System.Convert.ToInt32(parms[0]);
		}

		private void SetPixelFormat(int hCamera, PixelFormat pixelFormat)
		{
			FeatureFlags flags = 0;
			int numParms = 1;
			float[] parms = new float[numParms];
			Api.GetFeature(hCamera, Feature.PixelFormat,  ref flags, ref numParms, parms);
			parms[0] = (float)pixelFormat;
			Api.SetFeature(hCamera, Feature.PixelFormat, flags, numParms, parms);
		}


		private void ConfigFor8BitData(int hCamera)
		{
			PixelFormat currPixelFormat = GetPixelFormat(hCamera);
			PixelFormat newPixelFormat = PixelFormat.Bayer8;

			if (currPixelFormat == PixelFormat.Mono8) 
			{
				return;
			}

			if ((currPixelFormat == PixelFormat.Mono16))
			{
				newPixelFormat = PixelFormat.Mono8;
			}

			SetPixelFormat(hCamera, newPixelFormat);
		}


		void RunDemo() 
		{
			// Initialize a camera (any camera)
			int hCamera = 0;
			ReturnCode rc = Api.Initialize(0,ref hCamera);
			if (!Api.IsSuccess(rc)) 
			{
				return;
			}

			// Display some info about the camera we're using
			// (If there are multiple cameras, this will display which one we actually are connected to)
			GetCameraInfo(hCamera);

			// We're only going to deal with 8-bit data
			ConfigFor8BitData(hCamera);

			// Create a callback delegate
			// NOTE: This object must be referenced as long as the preview callback is being called.
			//       Failing to do so will cause the callback object to be garbage collected and 
			//       that will cause all kinds of unexpected and mysterious crashing. 
			Api.Callback cb = new Api.Callback(MyCallback);
			Console.WriteLine(cb.Method.CallingConvention);

			// Register the callback delegate with the API, saying that we want to see
			// frames as they come in.
			// See the PixeLINK API documentation for more info about the different kinds of 
			// overlays and what kind of data to expect with each.
			rc = Api.SetCallback(hCamera,Overlays.Frame, 0x0BADF00D, cb);

			// Start streaming and then sleep for a bit so that we can
			// start reporting some frame stats
			Api.SetStreamState(hCamera,StreamState.Start);
			Thread.Sleep(5 * 60 * 1000);
			Api.SetStreamState(hCamera,StreamState.Stop);


			Api.SetCallback(hCamera, Overlays.Frame, 0, null);

			Api.Uninitialize(hCamera);
		}

		// The callback function
		public static int MyCallback( 
			int hCamera,
			System.IntPtr pBuf,
			PixelFormat dataFormat,
			ref FrameDescriptor frameDesc,
			int context)
		{
			Console.WriteLine("Callback called");
			// Print a bit of data about the frame
			Console.WriteLine("  hCamera          = 0x{0}", Convert.ToString(hCamera,16));
			Console.WriteLine("  pBuf             = 0x{0}",	Convert.ToString((int)pBuf,16));
			Console.WriteLine("  dataFormat       = {0}",	dataFormat);
			Console.WriteLine("  frameDesc.Roi_Top    = {0}", frameDesc.RoiTop);
			Console.WriteLine("  frameDesc.Roi_Left   = {0}", frameDesc.RoiLeft);
			Console.WriteLine("  frameDesc.Roi_Height = {0}", frameDesc.RoiHeight);
			Console.WriteLine("  frameDesc.Roi_Width  = {0}", frameDesc.RoiWidth);
			Console.WriteLine("  context              = 0x{0}", Convert.ToString(context,16));

			// Get the image mean (knowing we're getting 8-bit data)
			long total = 0;
			long numPixels = frameDesc.NumberOfPixels();

#if OPTION_1
			// Have to compile with /unsafe
			unsafe 
			{
				byte* pData = (byte*)pBuf.ToPointer();
				for(int i=0; i < numPixels; i++) 
				{
						total += *pData++;
				}
			}
#endif

#if OPTION_2
			for(int i=0; i < numPixels; i++)
			{
				total += System.Runtime.InteropServices.Marshal.ReadByte(pBuf, i);
			}
#endif


			double mean = (double)total / (double)numPixels;
			Console.WriteLine("Image mean = {0}", mean);

			return 0;
		}


		public void GetCameraInfo(int hCamera)
		{
			CameraInformation info = new CameraInformation();
			ReturnCode rc = Api.GetCameraInformation(hCamera, ref info);
			Console.WriteLine(info.CameraName);
			Console.WriteLine(info.Description);
			Console.WriteLine(info.FirmwareVersion);
			Console.WriteLine(info.FpgaVersion);
			Console.WriteLine(info.ModelName);
			Console.WriteLine(info.SerialNumber);
			Console.WriteLine(info.VendorName);
		}
	}
}
