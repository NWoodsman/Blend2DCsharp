using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL.Gradient;


/// <summary>
/// <para>Represents the extent of a linear gradient in the form of two points. </para>
/// <para>Typically the points are placed at the outside edge of geometry to be filled.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public ref struct LinearGradientValues
{
	public double X0,Y0,X1,Y1;
}
