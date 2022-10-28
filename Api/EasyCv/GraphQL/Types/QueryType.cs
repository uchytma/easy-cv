using EasyCv.Core.Interfaces.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EasyCv.Api.GraphQL.Types
{

    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(f => f.GetResumeById(default!, default!));
        }
    }
}
