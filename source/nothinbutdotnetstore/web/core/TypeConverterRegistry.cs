using System;

namespace nothinbutdotnetstore.web.core
{
	public interface TypeConverterRegistry
	{
		ISimpleTypeConverter get_type_converter_for(Type type);
	}

	public interface ISimpleTypeConverter
	{
		object convert_from(string string_value);
	}
}