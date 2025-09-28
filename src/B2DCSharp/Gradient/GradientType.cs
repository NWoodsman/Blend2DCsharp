using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Gradient
{
	internal enum GradientType:UInt32
	{
		//! Linear gradient type.
		BL_GRADIENT_TYPE_LINEAR = 0,
		//! Radial gradient type.
		BL_GRADIENT_TYPE_RADIAL = 1,
		//! Conic gradient type.
		BL_GRADIENT_TYPE_CONIC = 2,

		//! Maximum value of `BLGradientType`.
		BL_GRADIENT_TYPE_MAX_VALUE = 2
	}
}
