using S100Framework.EventSourcing;

namespace VortexAPI
{
    public record ProductsCommandController : CommandController
    {
        public ProductsCommandController(EventStore eventStore) : base(eventStore) {
            //On<CreateProduct>((command) => {
            //    base.Apply(new EventSourcing.Products.v1.Created(command.ProductID));
            //});


            On<CreateProduct>()
                .GetId(cmd => $"product::{cmd.ProductID}")
                .Commit(new EventSourcing.Products.v1.Created(""));

            //On<UpdateName>()
            //    .GetId(cmd => $"product::{cmd.ProductID}")
            //    .Commit(new EventSourcing.Products.v1.NameUpdated());
        }

        public record CreateProduct(string ProductID);
        public record UpdateName(string Name);
    }
}
