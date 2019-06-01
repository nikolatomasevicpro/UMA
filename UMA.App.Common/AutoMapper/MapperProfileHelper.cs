using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UMA.App.Common.AutoMapper
{
    public sealed class Map
    {
        public Type Source { get; set; }
        public Type Destination { get; set; }
    }

    public static class MapperProfileHelper
    {
        public static IList<Map> LoadStandardMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        instance.IsGenericType && instance.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select new Map
                    {
                        Source = type.GetInterfaces().First().GetGenericArguments().First(),
                        Destination = type
                    }).ToList();

            return mapsFrom;
        }

        public static IList<IHaveCustomMapping> LoadCustomMappings(Assembly rootAssembly)
        {
            var types = rootAssembly.GetExportedTypes();

            var mapsFrom = (
                    from type in types
                    from instance in type.GetInterfaces()
                    where
                        typeof(IHaveCustomMapping).IsAssignableFrom(type) &&
                        !type.IsAbstract &&
                        !type.IsInterface
                    select (IHaveCustomMapping)Activator.CreateInstance(type)).ToList();

            return mapsFrom;
        }

        public static void AddCustomMappings(Profile configuration,  IList<IHaveCustomMapping> maps)
        {
            foreach (var map in maps)
            {
                map.CreateMappings(configuration);
            }
        }

        public static void AddStandardMappings(Profile configuration, IList<Map> maps)
        {
            foreach (var map in maps)
            {
                configuration.CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        public static void AutoMapStandard(Profile configuration, Assembly assembly)
        {
            AddStandardMappings(configuration, LoadStandardMappings(assembly));
        }

        public static void AutoMapCustom(Profile configuration, Assembly assembly)
        {
            AddCustomMappings(configuration, LoadCustomMappings(assembly));
        }
    }
}
