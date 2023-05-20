using Howest.MagicCards.GraphQL.Query;
using GraphQL.Types;

namespace Howest.MagicCards.GraphQL.Types
{
   public class RootSchema : Schema
   {
      public RootSchema(IServiceProvider provider) : base(provider)
      {
         Query = provider.GetRequiredService<RootQuery>();
      }
       
   } 
}
