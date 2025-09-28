using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Gradient
{
	public ref struct LinearGradient
	{
		internal nint selfhandle;
		public ResultCode AddStop(double offset, UInt32 argb32) => Lib.bl_gradient_add_stop_rgba32(ref selfhandle, offset, argb32);

		public static ResultCode Init(ref LinearGradientValues values, out LinearGradient gradient)
		{
			nint selfhandle = default;
			gradient = default;

			var result = Lib.bl_gradient_init_as(ref selfhandle, GradientType.BL_GRADIENT_TYPE_LINEAR, ref values, ExtendMode.BL_EXTEND_MODE_PAD, 0, 0, 0);

			if(result is ResultCode.BL_SUCCESS)
			{
				gradient = new LinearGradient { selfhandle = selfhandle };
			}

			return result;
		}
	}
}
