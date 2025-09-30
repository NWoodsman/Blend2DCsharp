using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public struct Path
{
	internal nint self_path_handle;

	public static ResultCode Init(out Path path)
	{
		path = new();

		var result = Lib.bl_path_init(out path.self_path_handle);

		return result;
	}

	public ResultCode MoveTo(double x0, double y0)
	{
		return Lib.bl_path_move_to(ref self_path_handle, x0, y0);
	}

	public ResultCode CubicTo(double x1,double y1, double x2, double y2, double x3, double y3)
	{
		return Lib.bl_path_cubic_to(ref self_path_handle, x1,y1,x2,y2,x3,y3);
	}
}
