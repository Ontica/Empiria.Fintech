/* Empiria Insurtech *****************************************************************************************
*                                                                                                            *
*  Module   : Policies Management                          Component : Interface adapters                    *
*  Assembly : Empiria.Insurtech.dll                        Pattern   : Output DTO                            *
*  Type     : ContractAgentcyInfoDto                       License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : ContractAgentcyInfo DTO for an insurance Contract.                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Insurtech.Policies.Adapters {

  /// <summary>Output DTO for Agency </summary>
  public class AgencyDto {

    public string UID {
      get; set;
    }

    public string Name {
      get; set;
    }

  } // class AgencyDto


  /// <summary>Output DTO for Agent </summary>
  public class AgentDto {

    public string UID {
      get; set;
    }

    public string Name {
      get; set;
    }

  } // class AgenctDto

} //class AgenctDto