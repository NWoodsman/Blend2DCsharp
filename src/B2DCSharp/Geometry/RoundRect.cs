using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL.Geometry;

[StructLayout(LayoutKind.Sequential)]
public struct RoundRect
{
	public double X,Y,W,H;
	public double Rx, Ry;
}
