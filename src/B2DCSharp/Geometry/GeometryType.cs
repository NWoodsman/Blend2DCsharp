using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Geometry;

internal enum GeometryType:UInt32
{
	//! No geometry provided.
	BL_GEOMETRY_TYPE_NONE = 0,
	//! BLBoxI struct.
	BL_GEOMETRY_TYPE_BOXI = 1,
	//! BLBox struct.
	BL_GEOMETRY_TYPE_BOXD = 2,
	//! BLRectI struct.
	BL_GEOMETRY_TYPE_RECTI = 3,
	//! BLRect struct.
	BL_GEOMETRY_TYPE_RECTD = 4,
	//! BLCircle struct.
	BL_GEOMETRY_TYPE_CIRCLE = 5,
	//! BLEllipse struct.
	BL_GEOMETRY_TYPE_ELLIPSE = 6,
	//! BLRoundRect struct.
	BL_GEOMETRY_TYPE_ROUND_RECT = 7,
	//! BLArc struct.
	BL_GEOMETRY_TYPE_ARC = 8,
	//! BLArc struct representing chord.
	BL_GEOMETRY_TYPE_CHORD = 9,
	//! BLArc struct representing pie.
	BL_GEOMETRY_TYPE_PIE = 10,
	//! BLLine struct.
	BL_GEOMETRY_TYPE_LINE = 11,
	//! BLTriangle struct.
	BL_GEOMETRY_TYPE_TRIANGLE = 12,
	//! BLArrayView<BLPointI> representing a polyline.
	BL_GEOMETRY_TYPE_POLYLINEI = 13,
	//! BLArrayView<BLPoint> representing a polyline.
	BL_GEOMETRY_TYPE_POLYLINED = 14,
	//! BLArrayView<BLPointI> representing a polygon.
	BL_GEOMETRY_TYPE_POLYGONI = 15,
	//! BLArrayView<BLPoint> representing a polygon.
	BL_GEOMETRY_TYPE_POLYGOND = 16,
	//! BLArrayView<BLBoxI> struct.
	BL_GEOMETRY_TYPE_ARRAY_VIEW_BOXI = 17,
	//! BLArrayView<BLBox> struct.
	BL_GEOMETRY_TYPE_ARRAY_VIEW_BOXD = 18,
	//! BLArrayView<BLRectI> struct.
	BL_GEOMETRY_TYPE_ARRAY_VIEW_RECTI = 19,
	//! BLArrayView<BLRect> struct.
	BL_GEOMETRY_TYPE_ARRAY_VIEW_RECTD = 20,
	//! BLPath (or BLPathCore).
	BL_GEOMETRY_TYPE_PATH = 21,

	//! Maximum value of `BLGeometryType`.
	BL_GEOMETRY_TYPE_MAX_VALUE = 21,

	//! \cond INTERNAL

	//! The last simple type.
	BL_GEOMETRY_TYPE_SIMPLE_LAST = BL_GEOMETRY_TYPE_TRIANGLE
}
