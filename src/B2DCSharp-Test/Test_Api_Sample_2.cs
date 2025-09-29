using BL;
using BL.Geometry;
using BL.Gradient;
using System.Runtime.CompilerServices;

namespace B2DCSharp_Test;

[TestClass]
public sealed class Test_API_Sample_2
{

	[TestMethod]
	public void Test()
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

		string path = @"api_sample_2.png";

		img.WriteToFile(path).Ok();
	}

}