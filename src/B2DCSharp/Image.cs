using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class Image
{
	nint handle_image_self;
	Context? context;

	public ResultCode ContextOpen(out Context? ctx)
	{
		ctx = null;

		if (context is null)
		{
			ContextImpl ctx1 = new ContextImpl();

			var result = Lib.bl_context_init_as(ref ctx1.selfhandle, ref handle_image_self, 0);

			// immediately move to begin() call, as that's how it is implemented in C++
			//result = Lib.bl_context_begin(ref handle_ctx);

			if (result is not ResultCode.BL_SUCCESS)
			{
				return result;
			}

			context = ctx1;

			ctx = ctx1;

			return result;

		}
		else throw new InvalidOperationException("Context must be closed before a new context can be opened");
	}

	public static ResultCode InitAs(int width, int height, Format format, out Image? img)
	{
		Image img1 = new Image();

		img = default;

		var result = Lib.bl_image_init_as(ref img1.handle_image_self, width, height, format);


		if (result is ResultCode.BL_SUCCESS)
		{
			img = img1;
			return result;
		}
		else
		{
			return result;
		}
	}
	public ResultCode WriteToFile(string path)
	{
		return Lib.bl_image_write_to_file(ref handle_image_self, path, 0);
	}

	private Image()
	{

	}
}
