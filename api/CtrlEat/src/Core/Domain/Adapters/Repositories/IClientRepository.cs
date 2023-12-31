﻿using Domain.Entities.ClientAggregate;
using Domain.Entities.ClientAggregate.ValueObjects;

namespace Domain.Adapters.Repositories;

public interface IClientRepository
{
    Task<int> CreateAsync(Client client, CancellationToken cancellationToken);

    Task<Client?> GetByIdAsync(ClientId id, CancellationToken cancellationToken);

    Task<Client?> GetByDocumentIdAsync(DocumentId documentId, CancellationToken cancellationToken);

    Task<Client?> GetByEmailAsync(Email email, CancellationToken cancellationToken);

    Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken);

    Task<int> UpdateAsync(Client client, CancellationToken cancellationToken);

    Task<int> DeleteAsync(Client client, CancellationToken cancellationToken);
}
