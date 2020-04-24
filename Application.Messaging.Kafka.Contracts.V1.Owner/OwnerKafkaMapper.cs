namespace Application.Messaging.Kafka.Contracts.V1.Owner
{
    using Application.DTO;

    public class OwnerKafkaMapper
    {
        public static OwnerKafka DTOToKafka(OwnerDTO dto)
        {
            var response = new OwnerKafka();

            if (dto == null)
            {
                return null;
            }

            response.Id = dto.Id;
            response.ExternalID = dto.ExternalID;
            response.Name = dto.Name;
            response.DateCreated = dto.DateCreated;
            response.DateUpdated = dto.DateUpdated;

            return response;
        }

        public static OwnerDTO KafkaToDTO(OwnerKafka owner)
        {
            var response = new OwnerDTO();

            if (owner == null)
            {
                return null;
            }

            response.Id = owner.Id;
            response.ExternalID = owner.ExternalID;
            response.Name = owner.Name;
            response.DateCreated = owner.DateCreated;
            response.DateUpdated = owner.DateUpdated;

            return response;
        }
    }
}
