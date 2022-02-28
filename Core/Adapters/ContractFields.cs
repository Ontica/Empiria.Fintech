/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Output DTO                            *
*  Type     : ContractFields                               License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Input DTO for an insurance contract.                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Insurtech.Policies.Adapters {
  /// <summary>Input DTO for an insurance contract.</summary>
  public class ContractFields {

    public string ContractUID {
      get; set;
    } = string.Empty;
    
    public string ContractTypeUID {
      get; set;
    }

    public string PaymentType {
      get; set;
    }

    public string ContractStartDate {
      get; set;
    }

    public PartyFields Beneficiary {
      get; set;
    }

    public PartyFields Contractor {
      get; set;
    }


  } //class ContractFields

} // Empiria.Insurtech.Policies.Adapters