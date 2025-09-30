using BL;
using BL.Geometry;
using BL.Gradient;
using System.Runtime.CompilerServices;

namespace B2DCSharp_Test;

[TestClass]
public sealed class Test_API_Sample_6
{
	[TestMethod]
	public void Test()
	{
		Image.InitAs(480, 480, Format.BL_FORMAT_PRGB32, out var img).Ok();

		img!.ContextOpen(out Context ctx).Ok();

		ctx!.ClearAll().Ok();

		LinearGradientValues vals = new LinearGradientValues() { X0 = 0, Y0 = 0, X1 = 0, Y1 = 480 };

		LinearGradient.Init(ref vals, out var lg).Ok();

		lg.AddStop(0.0, 0xFFFFFFFF).Ok();
		lg.AddStop(0.5, 0xFFFF1F7F).Ok();
		lg.AddStop(1.0, 0xFF1F7FFF).Ok();

		ctx.SetStrokeStyle(ref lg).Ok();

		BL.Path.Init(out var path).Ok();

		path.MoveTo(119d,49d).Ok();
		path.CubicTo(259d, 29d, 99d, 279d, 275d, 267d).Ok();
		path.CubicTo(537d,245d,300d,-170d,274d,430d).Ok();

		ctx.SetStrokeWidth(15d).Ok();
		ctx.SetStrokeCaps(StrokeCap.BL_STROKE_CAP_ROUND).Ok();

		//ctx.StrokePath(ref path, 0xFFFF1F7F).Ok();
		ctx.StrokePath(ref path).Ok();

		ctx.End().Ok();

		img.WriteToFile("api_sample_6.png");

	}

}
