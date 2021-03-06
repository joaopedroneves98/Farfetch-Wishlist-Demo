﻿namespace Application.Services.Implementations
{
    using Application.DTO;
    using Application.Services.Interfaces;
    using Data.Repository.Interfaces.Repositories;
    using Domain.Services.Mapping;
    using Producer;
    using System;
    using System.Collections.Generic;
    using Wishlist.Contracts.V1.Events;

    public class OwnerService : IOwnerService
    {

        private readonly IOwnerRepository ownerRepository;

        private readonly IOwnerProducer ownerProducer;

        public OwnerService(IOwnerRepository ownerRepository, IOwnerProducer ownerProducer)
        {
            this.ownerRepository = ownerRepository;
            this.ownerProducer = ownerProducer;
        }

        public async System.Threading.Tasks.Task<OwnerDTO> AddOwnerAsync(OwnerDTO dto)
        {
            var ownerToAdd = OwnerDTOMapper.DTOToObject(dto);
            if (ownerToAdd == null)
            {
                return null;
            }
            var ownerAdded = this.ownerRepository.AddOwner(ownerToAdd);
            await this.ownerProducer.SendMessageAsync(OwnerDTOMapper.ObjectToDTO(ownerAdded)).ConfigureAwait(false);
            return OwnerDTOMapper.ObjectToDTO(ownerAdded);
        }

        public OwnerDTO DeleteOwner(string ownerID)
        {
            var deletedOwner = this.ownerRepository.DeleteOwner(ownerID);
            if (deletedOwner == null)
            {
                return null;
            }
            return OwnerDTOMapper.ObjectToDTO(deletedOwner);

        }

        public List<OwnerDTO> GetAllOwners()
        {
            var owners = this.ownerRepository.GetAllOwners();
            List<OwnerDTO> resultOwners = new List<OwnerDTO>();
            foreach (var owner in owners)
            {
                resultOwners.Add(OwnerDTOMapper.ObjectToDTO(owner));
            }
            return resultOwners;
        }

        public OwnerDTO GetOwner(string ownerID)
        {
            var owner = this.ownerRepository.GetOwnerObject(ownerID);
            if (owner == null)
            {
                return null;
            }
            return OwnerDTOMapper.ObjectToDTO(owner);
        }

        public OwnerDTO UpdateOwner(OwnerDTO dto)
        {
            var updated = this.ownerRepository.UpdateOwner(OwnerDTOMapper.DTOToObject(dto));
            if (updated == null)
            {
                return null;
            }
            return OwnerDTOMapper.ObjectToDTO(updated);
        }
    }
}
