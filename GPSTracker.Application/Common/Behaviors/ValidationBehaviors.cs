using FluentValidation;
using MediatR;

namespace GPSTracker.Application.Common.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Count != 0) throw new ValidationException(failures);

            return await next();
        }
    }
}
