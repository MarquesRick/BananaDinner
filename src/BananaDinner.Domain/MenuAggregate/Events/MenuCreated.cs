using BananaDinner.Domain.Common.Models;

namespace BananaDinner.Domain.MenuAggregate.Events;

public record MenuCreated(Menu menu) : IDomainEvent;
