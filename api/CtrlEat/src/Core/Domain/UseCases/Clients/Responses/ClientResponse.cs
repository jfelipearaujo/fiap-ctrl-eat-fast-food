﻿using Domain.Entities;
using Domain.Enums;

namespace Domain.UseCases.Clients.Responses
{
    public class ClientResponse
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? DocumentId { get; set; }

        public DocumentType DocumentType { get; set; } = DocumentType.None;

        public bool IsAnonymous { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public DateTime UpdatedAtUtc { get; set; }

        // ---

        public static ClientResponse MapFromDomain(Client client)
        {
            return new ClientResponse
            {
                Id = client.Id.Value,
                FirstName = client.FullName?.FirstName,
                LastName = client.FullName?.LastName,
                Email = client.Email?.Address,
                DocumentId = client.PersonalDocument?.DocumentId,
                DocumentType = client.PersonalDocument?.DocumentType ?? DocumentType.None,
                IsAnonymous = client.IsAnonymous,
                CreatedAtUtc = client.CreatedAtUtc,
                UpdatedAtUtc = client.UpdatedAtUtc,
            };
        }
    }
}
