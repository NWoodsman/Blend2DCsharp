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
	public abstract ResultCode Fill(ref RoundRect rect);
	public abstract ResultCode SetFillStyle(ref LinearGradient gradient);
	public abstract ResultCode End();
}

internal class ContextImpl : Context
{
	internal nint imagehandle;
	internal nint selfhandle;

	public override ResultCode ClearAll() => Lib.bl_context_clear_all(ref selfhandle);

	public override ResultCode Fill(ref RoundRect rect)
	{
		return Lib.bl_context_fill_geometry(ref selfhandle, GeometryType.BL_GEOMETRY_TYPE_ROUND_RECT, ref rect);
	}
	public override ResultCode SetFillStyle(ref LinearGradient gradient)
	{
		return Lib.bl_context_set_fill_style(ref selfhandle, ref gradient.selfhandle);

	}
	public override ResultCode End()
	{
		return Lib.bl_context_end(selfhandle);
	}

	internal ContextImpl(nint imagehandle, nint selfhandle)
	{
		this.imagehandle = imagehandle;
		this.selfhandle = selfhandle;
	}
}

