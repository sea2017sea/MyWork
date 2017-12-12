using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmitMapper;

namespace Point.com.Assembler
{
    public class MapperImpl : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource tSource)
        {
            if (tSource == null)
                return default(TDestination);
            
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TSource, TDestination>();
            return mapper.Map(tSource);
        }

        public IEnumerable<TDestination> MapperGeneric<TSource, TDestination>(IEnumerable<TSource> tSources)
        {
            if (tSources == null)
                return null;

            IList<TDestination> tDestinations = new List<TDestination>();
            foreach (var tSource in tSources)
            {
                tDestinations.Add(Map<TSource, TDestination>(tSource));
            }
            return tDestinations;
        }

        public IList<TDestination> MapperGeneric<TSource, TDestination>(IList<TSource> tSources)
        {
            if (tSources == null)
                return null;

            IList<TDestination> tDestinations = new List<TDestination>();
            foreach (var tSource in tSources)
            {
                tDestinations.Add(Map<TSource, TDestination>(tSource));
            }
            return tDestinations;
        }
    }
}
