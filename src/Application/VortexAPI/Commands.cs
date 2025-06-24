using S100Framework.EventSourcing;

namespace VortexAPI
{
    public record ProductsCommandController : CommandController
    {
        public ProductsCommandController(EventStore eventStore) : base(eventStore) {
            //On<CreateProduct>((command) => {
            //    base.Apply(new EventSourcing.Products.v1.Created(command.ProductID));
            //});


            On<CreateProduct>().GetId(cmd => cmd.ProductID).Apply(new EventSourcing.Products.v1.Created(""));

        }

        public record CreateProduct(string ProductID);
    }
}
