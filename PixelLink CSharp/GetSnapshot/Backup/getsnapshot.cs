
using PixeLINK;
using System.IO;

namespace GetSnapshot
{

	public class SnapshotHelper
	{
		private int m_hCamera;

		public SnapshotHelper(int hCamera) 
		{
			m_hCamera = hCamera;
		}

		public bool GetSnapshot(ImageFormat imageFormat, string filename)
		{
			int rawImageSize = DetermineRawImageSize();
			byte[] buf = new byte[rawImageSize];

			Api.SetStreamState(m_hCamera, StreamState.Start);

			FrameDescriptor frameDesc = new FrameDescriptor();
			
			ReturnCode rc = Api.GetNextFrame(m_hCamera, buf.Length, buf, ref frameDesc);

			Api.SetStreamState(m_hCamera, StreamState.Stop);

			// How big a buffer do we need for the converted image?
			int destBufferSize = 0;
			rc = Api.FormatImage(buf, ref frameDesc, imageFormat, null, ref destBufferSize);
			byte[] dstBuf = new byte[destBufferSize];
			rc = Api.FormatImage(buf, ref frameDesc, imageFormat, dstBuf, ref destBufferSize);

			// Save the data to a binary file
			FileStream fStream = new FileStream(filename, FileMode.OpenOrCreate);
			BinaryWriter bw = new BinaryWriter(fStream);
			bw.Write(dstBuf);
			bw.Close();
			fStream.Close();

			return true;
		}	

		private ReturnCode GetNextFrame(ref FrameDescriptor frameDesc, byte[] buf)
		{
			ReturnCode rc = ReturnCode.UnknownError;
			const int NUM_TRIES = 4;
			for(int i=0; i < NUM_TRIES; i++) 
			{
				rc = Api.GetNextFrame(m_hCamera, buf.Length, buf, ref frameDesc);
				if (Api.IsSuccess(rc)) 
				{
					return rc;
				}
			}
			return rc;
		}

		private PixelFormat GetPixelFormat() 
		{
			FeatureFlags flags = 0;
			int numParms = 1;
			float[] parms = new float[numParms];
			Api.GetFeature(m_hCamera, Feature.PixelFormat,  ref flags, ref numParms, parms);
			return (PixelFormat)parms[0];
		}

		private int GetNumPixels()
		{
			// Query the ROI
			FeatureFlags flags = 0;
			int numParms = 4;
			float[] parms = new float[numParms];
			Api.GetFeature(m_hCamera, Feature.Roi,  ref flags, ref numParms, parms);

			int width = System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiWidth]);
			int height = System.Convert.ToInt32(parms[(int)FeatureParameterIndex.RoiHeight]);

			// Take the decimation (pixel addressing value) into account
			numParms = 2;
			Api.GetFeature(m_hCamera, Feature.PixelAddressing, ref flags, ref numParms, parms);
			int pixelAddressingValue = System.Convert.ToInt32(parms[(int)FeatureParameterIndex.PixelAddressingValue]);

			return (width / pixelAddressingValue) * (height / pixelAddressingValue);

		}

		//
		// This assumes there's no pixel addressing (decimation)
		//
		private int DetermineRawImageSize() 
		{
			float bytesPerPixel = Api.BytesPerPixel(GetPixelFormat());
			return (int) (bytesPerPixel * (float)GetNumPixels());
			
		}
	}

}