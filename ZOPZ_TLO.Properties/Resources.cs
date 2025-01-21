using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ZOPZ_TLO.Properties;

[DebuggerNonUserCode]
[CompilerGenerated]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager("ZOPZ_TLO.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap Building_With_Top_View
	{
		get
		{
			object @object = ResourceManager.GetObject("Building With Top View", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap copy
	{
		get
		{
			object @object = ResourceManager.GetObject("copy", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap copy1
	{
		get
		{
			object @object = ResourceManager.GetObject("copy1", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Identity_Theft
	{
		get
		{
			object @object = ResourceManager.GetObject("Identity Theft", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Identity_Theft1
	{
		get
		{
			object @object = ResourceManager.GetObject("Identity Theft1", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Location
	{
		get
		{
			object @object = ResourceManager.GetObject("Location", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Person
	{
		get
		{
			object @object = ResourceManager.GetObject("Person", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Person_Calendar
	{
		get
		{
			object @object = ResourceManager.GetObject("Person Calendar", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Phone
	{
		get
		{
			object @object = ResourceManager.GetObject("Phone", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Real_Estate
	{
		get
		{
			object @object = ResourceManager.GetObject("Real Estate", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Search
	{
		get
		{
			object @object = ResourceManager.GetObject("Search", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal static Bitmap Web_Address
	{
		get
		{
			object @object = ResourceManager.GetObject("Web Address", resourceCulture);
			return (Bitmap)@object;
		}
	}

	internal Resources()
	{
	}
}
