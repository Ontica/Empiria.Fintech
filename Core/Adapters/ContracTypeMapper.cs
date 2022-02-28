/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Mapper class                          *
*  Type     : ContractTypeDto                              License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Mapping methods for contract type.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Adapters {


  /// <summary>Mapping methods for contract type.</summary>  
  internal static class ContracTypeMapper {

    internal static FixedList<ContracTypeDto> Map(FixedList<ContractType> list) {
      var mapped = list.Select((x) => Map(x));

      return new FixedList<ContracTypeDto>(mapped);
    }

    internal static ContracTypeDto Map(ContractType contractType) {
      var dto = new ContracTypeDto {
        UID = contractType.UID,
        Name = contractType.Name
      };
      return dto;
    }

  } // class ContracTypeMapper

} // Empiria.Insurtech.Policies.Adapters