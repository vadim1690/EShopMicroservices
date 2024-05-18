
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id,string Name,List<string> Category, string Description, string ImageFile, decimal Price)
    :ICommand<UpdateProductResult>;

public record UpdateProductResult(Product Product);
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greated than 0");
    }
}

internal class UpdateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        // Update Product entity from command object
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product == null)
        {
            throw new ProductNotFoundException(command.Id);
        }
        // update
        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        // save to database
        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);
        // return UpdateProductResult result
        return new UpdateProductResult(product);
        
    }
}
