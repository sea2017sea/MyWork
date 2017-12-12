using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Point.com.Model
{
    public class RepositoryMemberAttribute : Attribute
    {
        public string MemberName { get; set; }
        public string Description { get; set; }
        public RepositoryMemberAttribute()
        {

        }

    }

    public class RepositoryAttribute : Attribute
    {
        public string DbName { get; set; }
        public string Description { get; set; }
    }
}