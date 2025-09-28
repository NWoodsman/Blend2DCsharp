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
	public void Test_BL_Image_Init()
	{
		var result = Image.Init(out _);

		Assert.IsTrue(result.Success());

	}

	[TestMethod]
	public void Test_BL_Image_Create()
	{
		var result = Image.Init(out var img);

		Assert.IsTrue(result.Success());

		img!.Create(480, 480, BL.Format.BL_FORMAT_PRGB32);

		Assert.IsTrue(result.Success());

	}

	[TestMethod]
	public void Test_BL_Image_Context()
	{
		Image.Init(out var img).Ok();

		img!.Create(480, 480, BL.Format.BL_FORMAT_PRGB32).Ok();

		img.ContextOpen(out Context ctx).Ok();

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

		string path = @"test_gradient.png";

		img.WriteToFile(path).Ok();
	}


}
static class Extensions
{
	public static bool Success(this BL.ResultCode code) => code is BL.ResultCode.BL_SUCCESS;

	public static void Ok(this BL.ResultCode code) => Assert.IsTrue(code.Success());
}
