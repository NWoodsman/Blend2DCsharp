using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class Image
{
	nint handle;
	Context? context;

	public ResultCode Create(int width, int height, Format format)
	{
		var result = Lib.bl_image_create(ref handle, width,height, format);

		return result;
	}

	public ResultCode ContextOpen(out Context? ctx)
	{
		ctx = null;

		if (context is null)
		{
			nint ctxhandle = default;

			//var result = Lib.ContextInit(ref ctxhandle, ref handle);
			var result = Lib.bl_context_init_as(ref ctxhandle, ref handle, 0);

			if (result is not ResultCode.BL_SUCCESS)
			{
				return result;
			}

			context = new ContextImpl(handle,ctxhandle);

			ctx = context;

			return result;

		}
		else throw new InvalidOperationException("Context must be closed before a new context can be opened");
	}

	public static ResultCode Init(out Image? img)
	{
		img = default;
		nint handle = default;

		var result = Lib.bl_image_init(ref handle);

		if (result is ResultCode.BL_SUCCESS)
		{
			img = new Image() { handle = handle };
			return result;
		}
		else
		{
			return result;
		}
	}
	public ResultCode WriteToFile(string path)
	{
		return Lib.bl_image_write_to_file(handle, path, 0);
	}

	private Image()
	{

	}
}
