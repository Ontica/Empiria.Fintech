/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Mapper class                          *
*  Type     : ContractDto                                  License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Mapping methods for contracts.                                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Collections.Generic;
using Empiria.Contacts;
using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Adapters {

  /// <summary>Mapping methods for policies.</summary>
  static internal class ContractMapper {

    static internal FixedList<ContractDto> Map(FixedList<Contract> contracts) {
      List<ContractDto> contractsDto = new List<ContractDto>();

      foreach (Contract contract in contracts) {
        contractsDto.Add(Map(contract));
      }

      return contractsDto.ToFixedList();
    }


    static internal ContractDto Map(Contract contract) {
      var dto = new ContractDto {
        ContractTrackId = contract.ContractTrackId,
        ContractTrackUID = contract.ContractTrackUID,
        ContractId = contract.ContractId,
        ContractTypeInfo = ContracTypeMapper.Map(contract.ContractType),
        ContractNo = contract.ContractNo,
        ContractStatus = contract.ContractStatus,
        ContractPaymentType = contract.ContractPayment,
        StartDate = contract.StartDate,
        EndDate = contract.EndDate,
        Parties = MapParties(contract.Parties),
        Agency = LoadAgency(contract.Agency),
        Agent = LoadAgent(contract.Agent)
      };

      return dto;
    }
        

    static internal FixedList<PartyDto> MapParties(List<Party> parties) {
      var partiesDto = new List<PartyDto>();

      foreach (var party in parties) {
        partiesDto.Add(PartyMapper.Map(party));
      }     
     
      return partiesDto.ToFixedList();
    }


    private static AgencyDto LoadAgency(Contact agency) {
      var agencyDto = new AgencyDto {
        UID = agency.UID,
        Name = agency.FullName
      };
      
      return agencyDto;
    }



    private static AgentDto LoadAgent(Contact agent) {
      var agentDto = new AgentDto {
        UID = agent.UID,
        Name = agent.FullName
      };

      return agentDto;
    }

  } // class ContractMapper  

} // namespace Empiria.Insurtech.Policies.Adapters