using S100Framework.EventSourcing;

namespace VortexAPI
{
    namespace EventSourcing
    {
        namespace Products
        {
            namespace v1
            {
                [EventType("Products.v1.Created")]
                public record Created(string ProductID);

                [EventType("Products.v1.NameUpdated")]
                public record NameUpdated(string Name);
            }
        }
    }

    namespace EventSourcing.DomainModel
    {
        public record ProductState : State<ProductState>
        {
            public string ProductID { get; set; } = string.Empty;

            public string Name { get; set; } = string.Empty;

            public ProductState() {
                On<Products.v1.Created>((state, evt) => {
                    return new ProductState {
                        ProductID = evt.ProductID,
                    };
                });

                On<Products.v1.NameUpdated>((state, evt) => {
                    return state with {
                        Name = evt.Name,
                    };
                });
            }
        }
    }
}
