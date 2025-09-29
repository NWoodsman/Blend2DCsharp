using BL;
using BL.Geometry;
using BL.Gradient;
using System.Runtime.CompilerServices;

namespace B2DCSharp_Test;

[TestClass]
public sealed class TestBLImage
{
	nint handle;

	[TestMethod]
	public void Test_API_ImageInit()
	{
		Image.InitAs(480, 480, BL.Format.BL_FORMAT_PRGB32, out Image? img).Ok();
	}


	[TestMethod]
	public void Test_lib_bl_image_init()
	{
		Image.InitAs(480, 480, BL.Format.BL_FORMAT_PRGB32, out Image? img).Ok();
	}

	[TestMethod]
	public void Test_API_ContextInitAs()
	{
		Image.InitAs(480, 480, BL.Format.BL_FORMAT_PRGB32, out Image? img).Ok();
		img!.ContextOpen(out var ctx).Ok();
	}

	[TestMethod]
	public void Test_lib_Sample2()
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

		Lib.bl_image_write_to_file(ref img_handle, "testoutput.png", 0).Ok();

	}

	[TestMethod]
	public void Test_API_Sample2()
	{

		Image.InitAs(480, 480, BL.Format.BL_FORMAT_PRGB32, out Image? img).Ok();

		img!.ContextOpen(out Context ctx).Ok();

		ctx!.ClearAll().Ok();

		LinearGradientValues values = new LinearGradientValues { X0 = 0, Y0 = 0, X1 = 0, Y1 = 480 };

		LinearGradient.Init(ref values, out var gradient).Ok();

		gradient.AddStop(0.0, 0xFFFFFFFF).Ok();
		gradient.AddStop(0.5, 0xFF5FAFDF).Ok();
		gradient.AddStop(1.0, 0xFF2F5FDF).Ok();

		ctx.SetFillStyle(ref gradient).Ok();
		
		RoundRect rect = new RoundRect { X = 40.0, Y = 40.0, W = 400.0, H = 400.0, Rx = 45.5, Ry = 45.5 };

		ctx.Fill(ref rect).Ok();

		ctx.End().Ok();

		string path = @"testgradient2.png";

		img.WriteToFile(path).Ok();
	}


}
static class Extensions
{
	public static bool Success(this BL.ResultCode code) => code is BL.ResultCode.BL_SUCCESS;

	public static void Ok(this BL.ResultCode code) => Assert.IsTrue(code.Success());
}
