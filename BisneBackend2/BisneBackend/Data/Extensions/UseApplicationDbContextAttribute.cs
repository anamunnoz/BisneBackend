using System.Reflection;
using BisneBackend.Data;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;


namespace BisneBackend.Data.Extensions
{
    public class UseApplicationDbContextAttribute: ObjectFieldDescriptorAttribute
    {

        protected override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member){
            descriptor.UseDbContext<MyDbContext>();
        }
    }
}
