using System.Reflection;
using GraphQL.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace GraphQL.Extensions
{
    // Allows to wrap GraphQL configuration code into attributes that can be applied to .NET type system members
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}