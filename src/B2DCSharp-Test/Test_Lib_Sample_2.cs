using BL;
using BL.Geometry;
using BL.Gradient;
using System.Runtime.CompilerServices;

namespace B2DCSharp_Test;

[TestClass]
public sealed class Test_Lib_Sample_2
{

	[TestMethod]
	public void Test()
	{
		nint img_handle;
		nint nullptr = 0;
		nint ctx_handle;

		Lib.bl_image_init_as(out img_handle, 480, 480, Format.BL_FORMAT_PRGB32).Ok();

		Lib.bl_context_init_as(out ctx_handle, ref img_handle, 0).Ok();

		Lib.bl_context_clear_all(ref ctx_handle).Ok();

		LinearGradientValues vals = new LinearGradientValues() { X0 = 0, Y0 = 0, X1 = 0, Y1 = 480 };

		nint gradient_handle;

		Lib.bl_gradient_init_as(out gradient_handle, GradientType.BL_GRADIENT_TYPE_LINEAR, vals, ExtendMode.BL_EXTEND_MODE_PAD,0,0,0).Ok();

		Lib.bl_gradient_add_stop_rgba32(ref gradient_handle, 0.0, 0xFFFFFFFF).Ok();
		Lib.bl_gradient_add_stop_rgba32(ref gradient_handle, 0.5, 0xFF5FAFDF).Ok();
		Lib.bl_gradient_add_stop_rgba32(ref gradient_handle, 1.0, 0xFF2F5FDF).Ok();


		Lib.bl_context_set_fill_style(ref ctx_handle, ref gradient_handle).Ok();

		RoundRect rect = new RoundRect() { X = 40, Y = 40, W = 400, H = 400, Rx = 45.5, Ry = 45.5 };

		Lib.bl_context_fill_geometry(ref ctx_handle, GeometryType.BL_GEOMETRY_TYPE_ROUND_RECT, rect).Ok();

		Lib.bl_context_end(ref ctx_handle).Ok();

		Lib.bl_image_write_to_file(ref img_handle, "lib_sample_2.png", 0).Ok();

	}
}

