using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;


namespace BisneBackend.AccesoDatos.Data.Extensions
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
