using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public enum ExtendMode:UInt32
{
	//! Pad extend [default].
	BL_EXTEND_MODE_PAD = 0,
	//! Repeat extend.
	BL_EXTEND_MODE_REPEAT = 1,
	//! Reflect extend.
	BL_EXTEND_MODE_REFLECT = 2,

	//! Alias of `BL_EXTEND_MODE_PAD`.
	BL_EXTEND_MODE_PAD_X_PAD_Y = 0,
	//! Pad X and repeat Y.
	BL_EXTEND_MODE_PAD_X_REPEAT_Y = 3,
	//! Pad X and reflect Y.
	BL_EXTEND_MODE_PAD_X_REFLECT_Y = 4,

	//! Alias of `BL_EXTEND_MODE_REPEAT`.
	BL_EXTEND_MODE_REPEAT_X_REPEAT_Y = 1,
	//! Repeat X and pad Y.
	BL_EXTEND_MODE_REPEAT_X_PAD_Y = 5,
	//! Repeat X and reflect Y.
	BL_EXTEND_MODE_REPEAT_X_REFLECT_Y = 6,

	//! Alias of `BL_EXTEND_MODE_REFLECT`.
	BL_EXTEND_MODE_REFLECT_X_REFLECT_Y = 2,
	//! Reflect X and pad Y.
	BL_EXTEND_MODE_REFLECT_X_PAD_Y = 7,
	//! Reflect X and repeat Y.
	BL_EXTEND_MODE_REFLECT_X_REPEAT_Y = 8,

	//! Count of simple extend modes (that use the same value for X and Y).
	BL_EXTEND_MODE_SIMPLE_MAX_VALUE = 2,
	//! Count of complex extend modes (that can use independent values for X and Y).
	BL_EXTEND_MODE_COMPLEX_MAX_VALUE = 8,

	//! Maximum value of `BLExtendMode`.
	BL_EXTEND_MODE_MAX_VALUE = 8
}
