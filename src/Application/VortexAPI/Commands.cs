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
                .Action((cmd, p) => {
                    p.Publish(() => new EventSourcing.Products.v1.Created(cmd.ProductID));
                });

            On<UpdateName>()
                .GetId(cmd => $"product::{cmd.ProductID}")
                .Action((cmd, p) => {
                    p.Publish(() => new EventSourcing.Products.v1.NameUpdated(cmd.Name));
                });
        }

    public record CreateProduct(string ProductID);

    public record UpdateName(string ProductID, string Name);
}
}
