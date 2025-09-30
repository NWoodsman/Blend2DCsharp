using BL.Geometry;
using BL.Gradient;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace BL;

internal static partial class Lib
{
	const string dllPath = @"..\..\..\..\..\..\lib\Blend2D\blend2d.dll";

	[LibraryImport(dllPath, EntryPoint = "bl_image_init_as")]
	internal static partial ResultCode bl_image_init_as(out nint handle, int width, int height, Format format);

	[LibraryImport(dllPath, EntryPoint = "bl_image_destroy")]
	internal static partial ResultCode bl_image_destroy(nint handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_begin")]
	internal static partial ResultCode bl_context_begin(ref nint image_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_clear_all")]
	internal static partial ResultCode bl_context_clear_all(ref nint contexhandle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_end")]
	internal static partial ResultCode bl_context_end(ref nint context_handle);
	
	[LibraryImport(dllPath, EntryPoint = "bl_context_fill_geometry")]
	internal static partial ResultCode bl_context_fill_geometry(ref nint context_handle, GeometryType type, RoundRect rect);

	[LibraryImport(dllPath, EntryPoint = "bl_context_init_as")]
	internal static partial ResultCode bl_context_init_as(out nint context_handle, ref nint image_handle, nint nullptr);

	[LibraryImport(dllPath, EntryPoint = "bl_context_set_fill_style")]
	internal static partial ResultCode bl_context_set_fill_style(ref nint context_handle, ref nint style_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_set_stroke_caps")]
	internal static partial ResultCode bl_context_set_stroke_caps(ref nint ctx_handle, StrokeCap cap);

	[LibraryImport(dllPath, EntryPoint = "bl_context_set_stroke_style")]
	internal static partial ResultCode bl_context_set_stroke_style(ref nint ctx_handle, ref nint style_handle );

	[LibraryImport(dllPath, EntryPoint = "bl_context_set_stroke_width")]
	internal static partial ResultCode bl_context_set_stroke_width(ref nint ctx_handle, double width);

	[LibraryImport(dllPath, EntryPoint = "bl_context_stroke_geometry")]
	internal static partial ResultCode bl_context_stroke_geometry(ref nint ctx_handle, GeometryType type, ref nint geometry_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_stroke_geometry_ext")]
	internal static partial ResultCode bl_context_stroke_geometry_ext(ref nint ctx_handle, GeometryType type, ref nint geometry_handle, ref nint style_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_stroke_geometry_rgba32")]
	internal static partial ResultCode bl_context_stroke_geometry_rgba32(ref nint ctx_handle, GeometryType type, ref nint geometry_handle, UInt32 strokecolor);

	[LibraryImport(dllPath, EntryPoint = "bl_gradient_init_as")]
	internal static partial ResultCode bl_gradient_init_as(out nint self, GradientType type, LinearGradientValues values, ExtendMode mode, nint stops_handle, nuint n, nint transform_handle);
		
	[LibraryImport(dllPath, EntryPoint = "bl_gradient_add_stop_rgba32")]
	internal static partial ResultCode bl_gradient_add_stop_rgba32(ref nint self, double offset, UInt32 argb32);

	[LibraryImport(dllPath, EntryPoint = "bl_image_write_to_file", StringMarshalling =StringMarshalling.Utf8)]
	internal static partial ResultCode bl_image_write_to_file(ref nint image_handle, string path, nint codec_handle);
	
	[LibraryImport(dllPath, EntryPoint = "bl_path_init")]
	internal static partial ResultCode bl_path_init(out nint path_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_path_move_to")]
	internal static partial ResultCode bl_path_move_to(ref nint path_handle, double x0, double y0);

	[LibraryImport(dllPath, EntryPoint = "bl_path_cubic_to")]
	internal static partial ResultCode bl_path_cubic_to(ref nint path_handle, double x1, double y1,double x2, double y2, double x3, double y3);



}
