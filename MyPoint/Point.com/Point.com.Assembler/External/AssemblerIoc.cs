using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Assembler
{
    public class AssemblerIoc
    {
        private static IMapper _mapper;
        public static IMapper GetMapper()
        {
            return _mapper ?? new MapperImpl();
        }
    }
}
