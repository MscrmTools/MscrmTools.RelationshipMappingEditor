using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MscrmTools.RelationshipMappingEditor.AppCode
{
    internal class MetadataHelper
    {
        public static List<EntityMetadata> RetrieveTables(IOrganizationService service, List<string> entitynames)
        {
            List<EntityMetadata> entities = new List<EntityMetadata>();

            if (entitynames.Count == 0) return entities;

            EntityQueryExpression entityQueryExpression = new EntityQueryExpression
            {
                Criteria = new MetadataFilterExpression(LogicalOperator.Or),
                Properties = new MetadataPropertiesExpression
                {
                    AllProperties = false,
                    PropertyNames = { "DisplayName", "SchemaName", "ObjectTypeCode", "IsIntersect", "Attributes" }
                }
            };

            entitynames.ForEach(entityname =>
            {
                entityQueryExpression.Criteria.Conditions.Add(new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, entityname));
            });

            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };

            var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);
            return response.EntityMetadata.ToList();
        }

        public static List<EntityMetadata> RetrieveTables(IOrganizationService oService, Guid solutionId)
        {
            List<EntityMetadata> entities = new List<EntityMetadata>();

            if (solutionId == Guid.Empty)
            {
                RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
                {
                    EntityFilters = EntityFilters.Entity | EntityFilters.Attributes
                };

                RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)oService.Execute(request);

                foreach (EntityMetadata emd in response.EntityMetadata)
                {
                    if (emd.DisplayName?.UserLocalizedLabel != null &&
                        (emd.IsCustomizable.Value || emd.IsManaged.Value == false))
                    {
                        entities.Add(emd);
                    }
                }
            }
            else
            {
                var components = oService.RetrieveMultiple(new QueryExpression("solutioncomponent")
                {
                    ColumnSet = new ColumnSet("objectid"),
                    NoLock = true,
                    Criteria = new FilterExpression
                    {
                        Conditions =
                        {
                            new ConditionExpression("solutionid", ConditionOperator.Equal, solutionId),
                            new ConditionExpression("componenttype", ConditionOperator.Equal, 1)
                        }
                    }
                }).Entities;

                var list = components.Select(component => component.GetAttributeValue<Guid>("objectid"))
                    .ToList();

                if (list.Count > 0)
                {
                    int i = 0;
                    List<Guid> metadataIds = list.Take(100).ToList();
                    do
                    {
                        EntityQueryExpression entityQueryExpression = new EntityQueryExpression
                        {
                            Criteria = new MetadataFilterExpression(LogicalOperator.Or),
                            Properties = new MetadataPropertiesExpression
                            {
                                AllProperties = false,
                                PropertyNames = { "DisplayName", "SchemaName", "ObjectTypeCode", "IsIntersect", "Attributes" }
                            }
                        };

                        metadataIds.ForEach(id =>
                        {
                            entityQueryExpression.Criteria.Conditions.Add(new MetadataConditionExpression("MetadataId", MetadataConditionOperator.Equals, id));
                        });

                        RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
                        {
                            Query = entityQueryExpression,
                            ClientVersionStamp = null
                        };

                        var response = (RetrieveMetadataChangesResponse)oService.Execute(retrieveMetadataChangesRequest);
                        entities.AddRange(response.EntityMetadata.Where(e => !(e.IsIntersect ?? false)));
                        i++;
                        metadataIds = list.Skip(i * 100).Take(100).ToList();
                    }
                    while (metadataIds.Count > 0);
                }
            }

            return entities;
        }
    }
}