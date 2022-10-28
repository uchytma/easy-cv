namespace EasyCv.Api.GraphQL.Types
{

    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(f => f.AddResume(default!, default!, default!));
        }
    }
}
