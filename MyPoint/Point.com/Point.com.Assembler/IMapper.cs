using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Assembler
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource tSource);

        IEnumerable<TDestination> MapperGeneric<TSource, TDestination>(IEnumerable<TSource> tSources);
        IList<TDestination> MapperGeneric<TSource, TDestination>(IList<TSource> tSources);
    }
}
