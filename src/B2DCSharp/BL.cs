using BL.Geometry;
using BL.Gradient;
using System;
using System.Runtime.InteropServices;

namespace BL;

internal static partial class Lib
{
	const string dllPath = @"..\..\..\..\..\..\lib\Blend2D\blend2d.dll";

	[LibraryImport(dllPath, EntryPoint = "bl_image_init_as")]
	internal static partial ResultCode bl_image_init_as(out nint handle, int width, int height, Format format);

	/*[LibraryImport(dllPath, EntryPoint = "bl_image_create")]
	internal static partial ResultCode bl_image_create(ref nint handle, int w, int h, Format format);*/

	[LibraryImport(dllPath, EntryPoint = "bl_image_destroy")]
	internal static partial ResultCode bl_image_destroy(nint handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_init_as")]
	internal static partial ResultCode bl_context_init_as(out nint context_handle, ref nint image_handle,nint nullptr);

	[LibraryImport(dllPath, EntryPoint = "bl_context_begin")]
	internal static partial ResultCode bl_context_begin(ref nint image_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_clear_all")]
	internal static partial ResultCode bl_context_clear_all(ref nint contexhandle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_fill_geometry")]
	internal static partial ResultCode bl_context_fill_geometry(ref nint context_handle, GeometryType type, RoundRect rect);

	[LibraryImport(dllPath, EntryPoint = "bl_gradient_init_as")]
	internal static partial ResultCode bl_gradient_init_as(out nint self, GradientType type, LinearGradientValues values, ExtendMode mode, nint stops_handle, nuint n, nint transform_handle);
		
	[LibraryImport(dllPath, EntryPoint = "bl_gradient_add_stop_rgba32")]
	internal static partial ResultCode bl_gradient_add_stop_rgba32(ref nint self, double offset, UInt32 argb32);

	[LibraryImport(dllPath, EntryPoint = "bl_context_set_fill_style")]
	internal static partial ResultCode bl_context_set_fill_style(ref nint context_handle, ref nint unknown_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_context_end")]
	internal static partial ResultCode bl_context_end(ref nint context_handle);

	[LibraryImport(dllPath, EntryPoint = "bl_image_write_to_file", StringMarshalling =StringMarshalling.Utf8)]
	internal static partial ResultCode bl_image_write_to_file(ref nint image_handle, string path, nint codec_handle);

}
