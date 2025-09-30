using BL.Geometry;
using BL.Gradient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public abstract class Context
{
	public abstract ResultCode ClearAll();
	public abstract ResultCode End();
	public abstract ResultCode Fill(ref RoundRect rect);
	public abstract ResultCode SetFillStyle(ref LinearGradient gradient);
	public abstract ResultCode SetStrokeCaps(StrokeCap strokeCap);
	public abstract ResultCode SetStrokeStyle(ref LinearGradient gradient);
	public abstract ResultCode SetStrokeWidth(double width);

	public abstract ResultCode StrokePath(ref Path path);
	public abstract ResultCode StrokePath(ref Path path, UInt32 color);

}

internal class ContextImpl : Context
{
	internal nint selfhandle; 

	public override ResultCode ClearAll() => Lib.bl_context_clear_all(ref selfhandle);

	public override ResultCode End()
	{
		return Lib.bl_context_end(ref selfhandle);
	}
	public override ResultCode Fill(ref RoundRect rect)
	{
		return Lib.bl_context_fill_geometry(ref selfhandle, GeometryType.BL_GEOMETRY_TYPE_ROUND_RECT, rect);
	}
	public override ResultCode SetFillStyle(ref LinearGradient gradient)
	{
		return Lib.bl_context_set_fill_style(ref selfhandle, ref gradient.selfhandle);

	}
	public override ResultCode SetStrokeCaps(StrokeCap strokeCap)
	{
		return Lib.bl_context_set_stroke_caps(ref selfhandle, strokeCap);
	}

	public override ResultCode SetStrokeStyle(ref LinearGradient gradient)
	{
		return Lib.bl_context_set_stroke_style(ref selfhandle, ref gradient.selfhandle);
	}

	public override ResultCode SetStrokeWidth(double width)
	{
		return Lib.bl_context_set_stroke_width(ref selfhandle, width);
	}
	public override ResultCode StrokePath(ref Path path)
	{
		return Lib.bl_context_stroke_geometry(ref selfhandle, GeometryType.BL_GEOMETRY_TYPE_PATH, ref path.self_path_handle);
	}
	public override ResultCode StrokePath(ref Path path, UInt32 color)
	{
		return Lib.bl_context_stroke_geometry_rgba32(ref selfhandle, GeometryType.BL_GEOMETRY_TYPE_PATH, ref path.self_path_handle, color);
	}


	internal ContextImpl() { }

	internal ContextImpl(nint self_ctx_handle)
	{
		this.selfhandle = self_ctx_handle;
	}
}

