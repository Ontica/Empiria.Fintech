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

using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Adapters {

  /// <summary>Mapping methods for policies.</summary>
  static internal class ContractMapper {

    static internal ContractDto Map(Contract contract) {
      var dto = new ContractDto {
        ContractTrackId = contract.ContractTrackId,
        ContractTrackUID = contract.ContractTrackUID,
        ContractId = contract.ContractId,
        ContractTypeInfo = ContracTypeMapper.Map(contract.ContractType),
        ContractNo = contract.ContractNo,
        ContractStatus = contract.ContractStatus,
        StartDate = contract.StartDate, 
        EndDate = contract.EndDate
      };

      return dto;
    }


  } // class ContractMapper  

} // namespace Empiria.Insurtech.Policies.Adapters