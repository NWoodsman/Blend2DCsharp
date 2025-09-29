using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2DCSharp_Test;

internal static class Extensions
{
	public static bool Success(this BL.ResultCode code) => code is BL.ResultCode.BL_SUCCESS;

	public static void Ok(this BL.ResultCode code) => Assert.IsTrue(code.Success());
}