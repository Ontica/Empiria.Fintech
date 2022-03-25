/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Output DTO                            *
*  Type     : ContractDto                                  License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Output DTO for an insurance Contract.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Insurtech.Policies.Domain;

namespace Empiria.Insurtech.Policies.Adapters {

  /// <summary>Output DTO for an insurance Contract.</summary>
  public class ContractDto {

    public int ContractTrackId {
      get; internal set;
    }

    public string ContractTrackUID {
      get; internal set;
    }

    public int ContractId {
      get; internal set;
    }

    public ContracTypeDto ContractTypeInfo {
      get; internal set;
    }

    public string ContractNo {
      get; internal set;
    }

    public char ContractStatus {
      get; internal set;
    }

    public string ContractPaymentType {
      get; internal set;
    }

    public DateTime StartDate {
      get; internal set;
    }

    public DateTime EndDate {
      get; internal set;
    }

    public FixedList<PartyDto> Parties{
      get; internal set;
    }

    public AgencyDto Agency {
      get; internal set;
    }

    public AgentDto Agent {
      get; internal set;
    }

  } // class ContractDto

} // Empiria.Insurtech.Policies.Adapters