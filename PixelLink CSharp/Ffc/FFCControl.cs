using System;
using System.Runtime.InteropServices;
using PixeLINK;



namespace ffc
{
	public class FFCControl
	{
		// Function through which magic values shall be passed to a camera.
		[DllImport("PxLApi40.dll", EntryPoint="PxLCameraWrite", CallingConvention=CallingConvention.StdCall)]
		private static extern ReturnCode CameraWrite(
			[In]		int hCamera, 
			[In]		int bufferSize,
			[In]		int[] buffer);

		// Generate and pass the magic values to the camera.
		static public ReturnCode Enable(int hCamera, bool enable)
		{
			int [] buffer = new int[3];
			buffer[0] = 0x00008002;
			buffer[1] = enable ? 1 : 0;
			return CameraWrite(hCamera, 12, buffer);
		}
	}
}
