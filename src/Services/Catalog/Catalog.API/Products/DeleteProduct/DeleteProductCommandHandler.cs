
using Catalog.API.Products.DeleteProduct;

namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id)
    :ICommand<DeleteProductResult>;

public record DeleteProductResult(Product Product);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id is required");
    }
}

internal class DeleteProductCommandHandler(IDocumentSession session)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        // Delete Product entity from command object
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product == null)
        {
            throw new ProductNotFoundException(command.Id);
        }


        // save to database
        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);
        // return DeleteProductResult result
        return new DeleteProductResult(product);
        
    }
}
