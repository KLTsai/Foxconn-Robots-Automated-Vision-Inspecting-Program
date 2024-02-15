using System;
using System.Diagnostics;
using PixeLINK;

// Triggering Demp App
//
// A simple example of the use of the three main triggering types: 
//  free-running
//  software
//  hardware
// 
// Note 1: We do NOT explore here the triggering modes such as 
// Mode 0 vs Mode 14 et cetera. The PixeLINK documentation provides 
// details about the various triggering modes.
//
// Note 2: We assume that there's only one PixeLINK camera connected to 
// the computer. 


namespace Triggering
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
			Class1 c = new Class1();
			c.RunTriggerDemo();
		}

		public void RunTriggerDemo()
		{
			// Initialize any camera
			int hCamera = 0;
			ReturnCode rc = Api.Initialize(0, ref hCamera);
			if (!Api.IsSuccess(rc)) 
			{
				Console.WriteLine("ERROR: Unable to initialize a camera");
				return;
			}

			DoTriggerDemo(hCamera);

			Api.Uninitialize(hCamera);
		}

		private void DoTriggerDemo(int hCamera)
		{
			// If the camera doesn't support triggering, we're done.
			if (!IsTriggeringSupported(hCamera)) 
			{
				Console.WriteLine("This camera does not support triggering.");
				Api.Uninitialize(hCamera);
				return;
			}

			// Start with triggering disabled so we start with a clean slate
			DisableTriggering(hCamera);

			// Test the three major types of triggering
			// We only use Mode 0 triggering.
			TestFreeRunningTrigger(hCamera);
			TestSoftwareTrigger(hCamera);
			TestHardwareTrigger(hCamera);

			// Put the camera back to a known state
			DisableTriggering(hCamera);
		}

		//
		// Not all PixeLINK cameras support triggering.
		// Machine vision cameras support triggering, but 
		// microscopy cameras do not.
		//
		//
		private bool IsTriggeringSupported(int hCamera)
		{
			CameraFeature featureInfo = new CameraFeature();
			ReturnCode rc = Api.GetCameraFeatures(hCamera, Feature.Trigger, ref featureInfo);
			Debug.Assert(Api.IsSuccess(rc));
			return featureInfo.IsSupported;
		}

		//
		// Set up the camera for triggering, and, enable triggering.
		//
		private void SetTriggering(int hCamera, int mode, TriggerType type, Polarity polarity, float delay, float param)
		{
			FeatureFlags flags = new FeatureFlags();
			int numParams = 5;
			float [] parameters = new float[numParams];

			// Read the current settings
			ReturnCode rc = Api.GetFeature(hCamera, Feature.Trigger, ref flags, ref numParams, parameters);
			Debug.Assert(Api.IsSuccess(rc));

			// Very important step: Enable triggering by clearing the FeatureFlags.Off bit
			flags &= (~FeatureFlags.Off);

			parameters[(int)FeatureParameterIndex.TriggerMode] = (float)mode;
			parameters[(int)FeatureParameterIndex.TriggerType] = (float)type;
			parameters[(int)FeatureParameterIndex.TriggerPolarity] = (float)polarity;
			parameters[(int)FeatureParameterIndex.TriggerDelay] = delay;
			parameters[(int)FeatureParameterIndex.TriggerParameter] = param;

			// And write the new settings
			rc = Api.SetFeature(hCamera, Feature.Trigger, flags, numParams, parameters);
			Debug.Assert(Api.IsSuccess(rc));


		}

		private void DisableTriggering(int hCamera)
		{
			FeatureFlags flags = new FeatureFlags();
			int numParams = 5;
			float[] parameters = new float[5];
			ReturnCode rc = Api.GetFeature(hCamera, Feature.Trigger, ref flags, ref numParams, parameters);
			Debug.Assert(Api.IsSuccess(rc));

			flags |= FeatureFlags.Off;

			rc = Api.SetFeature(hCamera, Feature.Trigger, flags, numParams, parameters);
			Debug.Assert(Api.IsSuccess(rc));

			return;
		}

		//
		// Quick and dirty routine to capture an image (and do nothing with it)
		//
		private void CaptureImage(int hCamera)
		{
			byte [] buffer = new byte[3000*3000*2]; // buffer big enough for any current PixeLINK camera
			FrameDescriptor frameDesc = new FrameDescriptor(); // ctor sets size for us

			ReturnCode rc = Api.GetNextFrame(hCamera, buffer.Length, buffer, ref frameDesc);
			Debug.Assert(Api.IsSuccess(rc));

		}

		//
		// With free running triggering, the camera is triggering itself to
		// continually capture images. 
		//
		private void TestFreeRunningTrigger(int hCamera) 
		{
			Console.WriteLine("\nConfiguring the camera for free running triggering");
			SetTriggering(hCamera, 
				0,								// Mode 0 Triggering
				TriggerType.FreeRunning, 
				Polarity.Negative, 
				0.0f,							// no delay
				0);								// unused for Mode 0

			// We can now grab two images (without blocking)
			ReturnCode rc = Api.SetStreamState(hCamera, StreamState.Start);
			Debug.Assert(Api.IsSuccess(rc));

			Console.WriteLine("Capturing two images...");
			CaptureImage(hCamera);
			CaptureImage(hCamera);
			Console.WriteLine("done.");

			rc = Api.SetStreamState(hCamera, StreamState.Stop);
			Debug.Assert(Api.IsSuccess(rc));
		}

		//
		// With software triggering, calling GetNextFrame causes 
		// the camera to capture an image. The camera must be in the 
		// streaming state, but no image will be 'streamed' to the host
		// until GetNextFrame is called.
		//
		private void TestSoftwareTrigger(int hCamera) 
		{
			Console.WriteLine("\nConfiguring the camera for software triggering");
			SetTriggering(hCamera, 
				0,								// Mode 0 Triggering
				TriggerType.Software, 
				Polarity.Negative, 
				0.0f,							// no delay
				0);								// unused for Mode 0

			// We can now grab two images (without blocking)
			ReturnCode rc = Api.SetStreamState(hCamera, StreamState.Start);
			Debug.Assert(Api.IsSuccess(rc));

			Console.WriteLine("Capturing two images...");
			CaptureImage(hCamera);
			CaptureImage(hCamera);
			Console.WriteLine("done.");

			rc = Api.SetStreamState(hCamera, StreamState.Stop);
			Debug.Assert(Api.IsSuccess(rc));

		}

		//
		// With hardware triggering, the camera doesn't take an image until the 
		// trigger input of the machine vision connector is activated. 
		//
		private void TestHardwareTrigger(int hCamera)
		{
			Console.WriteLine("\nConfiguring the camera for hardware triggering");
			SetTriggering(hCamera, 
				0,								// Mode 0 Triggering
				TriggerType.Hardware, 
				Polarity.Negative, 
				0.0f,							// no delay
				0);								// unused for Mode 0

			// We can now grab two images
			ReturnCode rc = Api.SetStreamState(hCamera, StreamState.Start);
			Debug.Assert(Api.IsSuccess(rc));

			Console.WriteLine("Waiting for a hardware trigger...");
			CaptureImage(hCamera);
			Console.WriteLine("Image captured.");

			Console.WriteLine("Waiting for one more hardware trigger...");
			CaptureImage(hCamera);
			Console.WriteLine("Image captured.");

			rc = Api.SetStreamState(hCamera, StreamState.Stop);
			Debug.Assert(Api.IsSuccess(rc));
		}



	}
}
