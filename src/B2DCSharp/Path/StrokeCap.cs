using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;
public enum StrokeCap : UInt32
{
	//! Butt cap [default].
	BL_STROKE_CAP_BUTT = 0,
	//! Square cap.
	BL_STROKE_CAP_SQUARE = 1,
	//! Round cap.
	BL_STROKE_CAP_ROUND = 2,
	//! Round cap reversed.
	BL_STROKE_CAP_ROUND_REV = 3,
	//! Triangle cap.
	BL_STROKE_CAP_TRIANGLE = 4,
	//! Triangle cap reversed.
	BL_STROKE_CAP_TRIANGLE_REV = 5,

	//! Maximum value of `BLStrokeCap`.
	BL_STROKE_CAP_MAX_VALUE = 5
}
