using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public enum Format : UInt32
	{
		//! None or invalid pixel format.
		BL_FORMAT_NONE = 0,
		//! 32-bit premultiplied ARGB pixel format (8-bit components).
		BL_FORMAT_PRGB32 = 1,
		//! 32-bit (X)RGB pixel format (8-bit components, alpha ignored).
		BL_FORMAT_XRGB32 = 2,
		//! 8-bit alpha-only pixel format.
		BL_FORMAT_A8 = 3,

		// Maximum value of `BLFormat`.
		BL_FORMAT_MAX_VALUE = 3
	}
}
